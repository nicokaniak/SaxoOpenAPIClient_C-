using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Orders.Models;
using System.Collections.Generic;

namespace SaxoOpenAPIClient.Services.Trading.Orders
{
    /// <summary>
    /// Service for handling all order-related operations in the Saxo Bank Trading API
    /// </summary>
    public interface IOrdersService : ISaxoService
    {
        // Single Order Operations
        Task<OrderResponse> PlaceOrderAsync(OrderRequest request);
        Task<OrderResponse> ModifyOrderAsync(string orderId, OrderModifyRequest request);
        Task<OrderResponse> CancelOrderAsync(string orderId);
        Task<OrderResponse> CancelOrdersForInstrumentAsync(string accountKey, int uic, string assetType);
        Task<IEnumerable<OrderResponse>> CancelMultipleOrdersAsync(IEnumerable<string> orderIds);

        // Bulk Order Operations
        Task<BulkOrderResponse> PlaceBulkOrdersAsync(IEnumerable<OrderRequest> requests);
        Task<BulkOrderResponse> ModifyBulkOrdersAsync(IEnumerable<OrderModifyRequest> requests);
        
        // Multi-leg Option Strategy Orders
        Task<MultiLegOrderResponse> PlaceMultiLegOrderAsync(MultiLegOrderRequest request);
        Task<MultiLegOrderResponse> ModifyMultiLegOrderAsync(string multiLegOrderId, MultiLegOrderModifyRequest request);
        Task CancelMultiLegOrderAsync(string multiLegOrderId);
        Task<MultiLegDefaults> GetMultiLegDefaultsAsync(string assetType, string strategyType);
        
        // Order Validation and Pre-checks
        Task<OrderPrecheck> PrecheckOrderAsync(OrderRequest request);
        Task<MultiLegOrderPrecheck> PrecheckMultiLegOrderAsync(MultiLegOrderRequest request);
        
        // Order Query and Monitoring
        Task<OrderInfo> GetOrderAsync(string orderId);
        Task<OrderList> GetOrdersAsync(string accountKey, OrderQueryParams queryParams = null);
        Task<OrderSubscription> SubscribeToOrdersAsync(string accountKey);
        Task<OrderCapabilities> GetOrderCapabilitiesAsync(int uic, string assetType);
        
        // Conditional and Related Orders
        Task<RelatedOrderResponse> PlaceRelatedOrderAsync(string parentOrderId, RelatedOrderRequest request);
        Task<ConditionalOrderResponse> PlaceConditionalOrderAsync(ConditionalOrderRequest request);
        Task<OCOOrderResponse> PlaceOCOOrderAsync(OCOOrderRequest request);
        
        // Order Templates
        Task<OrderTemplate> SaveOrderTemplateAsync(OrderTemplateRequest request);
        Task<IEnumerable<OrderTemplate>> GetOrderTemplatesAsync();
        Task DeleteOrderTemplateAsync(string templateId);
    }
}
