using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IOrdersService : ISaxoService
    {
        Task<OrderResponse> PlaceOrderAsync(OrderRequest request);
        Task<OrderResponse> ModifyOrderAsync(string orderId, OrderRequest request);
        Task CancelOrderAsync(string orderId);
        Task<OrderInfo> GetOrderAsync(string orderId);
        Task<OrderList> GetOrdersAsync(string accountKey);
        Task<OrderPrecheck> PrecheckOrderAsync(OrderRequest request);
        Task<OrderCapabilities> GetOrderCapabilitiesAsync(int uic, string assetType);
        Task<OrderSubscription> SubscribeToOrdersAsync(string accountKey);
        Task<BulkOrderResponse> PlaceBulkOrdersAsync(BulkOrderRequest request);
        Task<ConditionalOrderResponse> PlaceConditionalOrderAsync(ConditionalOrderRequest request);
    }
}
