using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Root.Models;

namespace SaxoOpenAPIClient.Services.Root
{
    /// <summary>
    /// Implementation of the Saxo Bank Root API services
    /// </summary>
    public class RootService : BaseSaxoService, IRootService
    {
        public override string BaseEndpoint => ServiceEndpoints.RootServices;

        public RootService(ISaxoClient client) : base(client) { }

        public async Task<SessionInfo> GetSessionAsync()
        {
            return await Client.GetAsync<SessionInfo>(
                BuildEndpoint($"{ApiVersions.Root.V1}/sessions/current"));
        }

        public async Task<FeatureAvailability> GetFeaturesAsync()
        {
            return await Client.GetAsync<FeatureAvailability>(
                BuildEndpoint($"{ApiVersions.Root.V1}/features"));
        }

        public async Task<UserInfo> GetUserInfoV1Async()
        {
            return await Client.GetAsync<UserInfo>(
                BuildEndpoint($"{ApiVersions.Root.V1}/user"));
        }

        public async Task<UserInfoV2> GetUserInfoV2Async()
        {
            return await Client.GetAsync<UserInfoV2>(
                BuildEndpoint($"{ApiVersions.Root.V2}/user"));
        }

        public async Task<DiagnosticsInfo> GetDiagnosticsAsync()
        {
            return await Client.GetAsync<DiagnosticsInfo>(
                BuildEndpoint($"{ApiVersions.Root.V1}/diagnostics"));
        }

        public async Task<SubscriptionList> GetSubscriptionsAsync()
        {
            return await Client.GetAsync<SubscriptionList>(
                BuildEndpoint($"{ApiVersions.Root.V1}/subscriptions"));
        }

        public async Task RemoveSubscriptionAsync(string contextId, string referenceId)
        {
            await Client.DeleteAsync(
                BuildEndpoint($"{ApiVersions.Root.V1}/subscriptions/{contextId}/{referenceId}"));
        }

        public async Task<RateLimitInfo> GetRateLimitStatusAsync()
        {
            return await Client.GetAsync<RateLimitInfo>(
                BuildEndpoint($"{ApiVersions.Root.V1}/ratelimit"));
        }
    }
}
