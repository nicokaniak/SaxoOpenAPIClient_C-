using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    /// <summary>
    /// Implementation of Saxo Bank Trading API operations
    /// </summary>
    public class TradingService : BaseSaxoService, ITradingService
    {
        public override string BaseEndpoint => ServiceEndpoints.Trading;

        public TradingService(ISaxoClient client) : base(client) { }

        public async Task<OrderResponse> PlaceOrderAsync(OrderRequest request)
        {
            return await Client.PostAsync<OrderRequest, OrderResponse>(
                BuildEndpoint("orders"), request);
        }

        public async Task<OrderResponse> ModifyOrderAsync(string orderId, OrderRequest request)
        {
            return await Client.PutAsync<OrderRequest, OrderResponse>(
                BuildEndpoint($"orders/{orderId}"), request);
        }

        public async Task CancelOrderAsync(string orderId)
        {
            await Client.DeleteAsync(BuildEndpoint($"orders/{orderId}"));
        }

        public async Task<OrderInfo> GetOrderAsync(string orderId)
        {
            return await Client.GetAsync<OrderInfo>(BuildEndpoint($"orders/{orderId}"));
        }

        public async Task<OrderList> GetOrdersAsync(string accountKey)
        {
            return await Client.GetAsync<OrderList>(BuildEndpoint($"orders?AccountKey={accountKey}"));
        }

        public async Task<PositionList> GetPositionsAsync(string accountKey)
        {
            return await Client.GetAsync<PositionList>(BuildEndpoint($"positions?AccountKey={accountKey}"));
        }
    }
}
