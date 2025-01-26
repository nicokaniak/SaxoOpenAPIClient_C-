using System.Threading.Tasks;
using SaxoOpenAPIClient.Authentication.Models;

namespace SaxoOpenAPIClient.Authentication
{
    /// <summary>
    /// Interface for Saxo Bank authentication services
    /// </summary>
    public interface IAuthenticationService
    {
        /// <summary>
        /// Generate PKCE code verifier and challenge
        /// </summary>
        Task<(string CodeVerifier, string CodeChallenge)> GeneratePkceValuesAsync();

        /// <summary>
        /// Get the authorization URL for OAuth2 flows
        /// </summary>
        Task<string> GetAuthorizationUrlAsync(AuthorizationRequest request);

        /// <summary>
        /// Exchange authorization code for tokens
        /// </summary>
        Task<TokenResponse> GetTokenFromCodeAsync(TokenRequest request);

        /// <summary>
        /// Get token using certificate-based authentication
        /// </summary>
        Task<TokenResponse> GetTokenWithCertificateAsync(CertificateAuthRequest request);

        /// <summary>
        /// Refresh an expired token
        /// </summary>
        Task<TokenResponse> RefreshTokenAsync(RefreshTokenRequest request);

        /// <summary>
        /// Validate the current token
        /// </summary>
        Task<bool> ValidateTokenAsync(string token);

        /// <summary>
        /// Revoke the current token
        /// </summary>
        Task RevokeTokenAsync(string token);
    }
}
