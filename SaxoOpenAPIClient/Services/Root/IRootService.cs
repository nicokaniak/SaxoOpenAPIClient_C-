using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Root.Models;

namespace SaxoOpenAPIClient.Services.Root
{
    /// <summary>
    /// Interface for Saxo Bank Root API services
    /// Provides access to fundamental API functionality like sessions, features, and user information
    /// </summary>
    public interface IRootService : ISaxoService
    {
        /// <summary>
        /// Gets the current session information
        /// </summary>
        Task<SessionInfo> GetSessionAsync();

        /// <summary>
        /// Gets the list of available features for the current context
        /// </summary>
        Task<FeatureAvailability> GetFeaturesAsync();

        /// <summary>
        /// Gets the current user information (v1)
        /// </summary>
        Task<UserInfo> GetUserInfoV1Async();

        /// <summary>
        /// Gets the current user information (v2)
        /// </summary>
        Task<UserInfoV2> GetUserInfoV2Async();

        /// <summary>
        /// Gets diagnostic information about the API
        /// </summary>
        Task<DiagnosticsInfo> GetDiagnosticsAsync();

        /// <summary>
        /// Gets the list of active subscriptions
        /// </summary>
        Task<SubscriptionList> GetSubscriptionsAsync();

        /// <summary>
        /// Removes a subscription by its reference id
        /// </summary>
        Task RemoveSubscriptionAsync(string contextId, string referenceId);

        /// <summary>
        /// Gets the current API rate limit status
        /// </summary>
        Task<RateLimitInfo> GetRateLimitStatusAsync();
    }
}
