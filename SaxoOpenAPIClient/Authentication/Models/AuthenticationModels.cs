using System;
using System.Text.Json.Serialization;

namespace SaxoOpenAPIClient.Authentication.Models
{
    /// <summary>
    /// OAuth2 token response
    /// </summary>
    public class TokenResponse
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }

        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }

        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }

        [JsonPropertyName("base_uri")]
        public string BaseUri { get; set; }
    }

    /// <summary>
    /// OAuth2 token request
    /// </summary>
    public class TokenRequest
    {
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; }

        [JsonPropertyName("code")]
        public string Code { get; set; }

        [JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("code_verifier")]
        public string CodeVerifier { get; set; }
    }

    /// <summary>
    /// PKCE code challenge method
    /// </summary>
    public enum CodeChallengeMethod
    {
        Plain,
        S256
    }

    /// <summary>
    /// OAuth2 authorization request parameters
    /// </summary>
    public class AuthorizationRequest
    {
        [JsonPropertyName("response_type")]
        public string ResponseType { get; set; } = "code";

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("redirect_uri")]
        public string RedirectUri { get; set; }

        [JsonPropertyName("code_challenge")]
        public string CodeChallenge { get; set; }

        [JsonPropertyName("code_challenge_method")]
        public string CodeChallengeMethod { get; set; }
    }

    /// <summary>
    /// Token refresh request
    /// </summary>
    public class RefreshTokenRequest
    {
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "refresh_token";

        [JsonPropertyName("refresh_token")]
        public string RefreshToken { get; set; }

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }
    }

    /// <summary>
    /// Certificate-based authentication request
    /// </summary>
    public class CertificateAuthRequest
    {
        [JsonPropertyName("grant_type")]
        public string GrantType { get; set; } = "client_credentials";

        [JsonPropertyName("client_id")]
        public string ClientId { get; set; }

        [JsonPropertyName("client_secret")]
        public string ClientSecret { get; set; }

        [JsonPropertyName("cert_file")]
        public string CertificateFile { get; set; }

        [JsonPropertyName("cert_password")]
        public string CertificatePassword { get; set; }
    }
}
