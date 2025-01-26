using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Web;
using Microsoft.Extensions.Options;
using SaxoOpenAPIClient.Authentication.Models;

namespace SaxoOpenAPIClient.Authentication
{
    /// <summary>
    /// Implementation of Saxo Bank authentication services
    /// </summary>
    public class AuthenticationService : IAuthenticationService
    {
        private readonly HttpClient _httpClient;
        private readonly SaxoClientOptions _options;
        private readonly JsonSerializerOptions _jsonOptions;

        public AuthenticationService(
            HttpClient httpClient,
            IOptions<SaxoClientOptions> options)
        {
            _httpClient = httpClient;
            _options = options.Value;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<(string CodeVerifier, string CodeChallenge)> GeneratePkceValuesAsync()
        {
            var verifier = GenerateCodeVerifier();
            var challenge = await GenerateCodeChallengeAsync(verifier);
            return (verifier, challenge);
        }

        public async Task<string> GetAuthorizationUrlAsync(AuthorizationRequest request)
        {
            var queryParams = new[]
            {
                ("response_type", request.ResponseType),
                ("client_id", request.ClientId),
                ("state", request.State),
                ("redirect_uri", request.RedirectUri)
            };

            var queryString = string.Join("&", Array.ConvertAll(queryParams, 
                p => $"{HttpUtility.UrlEncode(p.Item1)}={HttpUtility.UrlEncode(p.Item2)}"));

            if (!string.IsNullOrEmpty(request.CodeChallenge))
            {
                queryString += $"&code_challenge={HttpUtility.UrlEncode(request.CodeChallenge)}";
                queryString += $"&code_challenge_method={HttpUtility.UrlEncode(request.CodeChallengeMethod)}";
            }

            return $"{_options.AuthorizationEndpoint}?{queryString}";
        }

        public async Task<TokenResponse> GetTokenFromCodeAsync(TokenRequest request)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "authorization_code"),
                new KeyValuePair<string, string>("code", request.Code),
                new KeyValuePair<string, string>("redirect_uri", request.RedirectUri),
                new KeyValuePair<string, string>("client_id", request.ClientId)
            });

            if (!string.IsNullOrEmpty(request.ClientSecret))
            {
                content.Headers.Add("Authorization", 
                    $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{request.ClientId}:{request.ClientSecret}"))}");
            }

            if (!string.IsNullOrEmpty(request.CodeVerifier))
            {
                content.Headers.Add("code_verifier", request.CodeVerifier);
            }

            var response = await _httpClient.PostAsync(_options.TokenEndpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new SaxoAuthenticationException($"Failed to get token: {responseContent}");
            }

            return JsonSerializer.Deserialize<TokenResponse>(responseContent, _jsonOptions);
        }

        public async Task<TokenResponse> GetTokenWithCertificateAsync(CertificateAuthRequest request)
        {
            using var cert = new X509Certificate2(request.CertificateFile, request.CertificatePassword);
            
            var handler = new HttpClientHandler();
            handler.ClientCertificates.Add(cert);

            using var client = new HttpClient(handler);

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", request.GrantType),
                new KeyValuePair<string, string>("client_id", request.ClientId)
            });

            if (!string.IsNullOrEmpty(request.ClientSecret))
            {
                content.Headers.Add("Authorization", 
                    $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{request.ClientId}:{request.ClientSecret}"))}");
            }

            var response = await client.PostAsync(_options.TokenEndpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new SaxoAuthenticationException($"Failed to get token with certificate: {responseContent}");
            }

            return JsonSerializer.Deserialize<TokenResponse>(responseContent, _jsonOptions);
        }

        public async Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request)
        {
            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", request.GrantType),
                new KeyValuePair<string, string>("refresh_token", request.RefreshToken),
                new KeyValuePair<string, string>("client_id", request.ClientId)
            });

            if (!string.IsNullOrEmpty(request.ClientSecret))
            {
                content.Headers.Add("Authorization", 
                    $"Basic {Convert.ToBase64String(Encoding.UTF8.GetBytes($"{request.ClientId}:{request.ClientSecret}"))}");
            }

            var response = await _httpClient.PostAsync(_options.TokenEndpoint, content);
            var responseContent = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                throw new SaxoAuthenticationException($"Failed to refresh token: {responseContent}");
            }

            return JsonSerializer.Deserialize<TokenResponse>(responseContent, _jsonOptions);
        }

        public async Task<bool> ValidateTokenAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, _options.TokenValidationEndpoint);
            request.Headers.Add("Authorization", $"Bearer {token}");

            var response = await _httpClient.SendAsync(request);
            return response.IsSuccessStatusCode;
        }

        public async Task RevokeTokenAsync(string token)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, _options.TokenRevocationEndpoint);
            request.Headers.Add("Authorization", $"Bearer {token}");

            var response = await _httpClient.SendAsync(request);
            
            if (!response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                throw new SaxoAuthenticationException($"Failed to revoke token: {content}");
            }
        }

        private string GenerateCodeVerifier()
        {
            var bytes = new byte[32];
            using var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return Convert.ToBase64String(bytes)
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
        }

        private async Task<string> GenerateCodeChallengeAsync(string verifier)
        {
            using var sha256 = SHA256.Create();
            var challengeBytes = await Task.Run(() => sha256.ComputeHash(Encoding.UTF8.GetBytes(verifier)));
            return Convert.ToBase64String(challengeBytes)
                .TrimEnd('=')
                .Replace('+', '-')
                .Replace('/', '_');
        }
    }

    public class SaxoAuthenticationException : Exception
    {
        public SaxoAuthenticationException(string message) : base(message) { }
    }
}
