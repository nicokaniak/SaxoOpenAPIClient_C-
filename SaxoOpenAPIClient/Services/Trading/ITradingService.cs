using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    /// <summary>
    /// Interface for Saxo Bank Trading API operations
    /// </summary>
    public interface ITradingService : ISaxoService
    {
        Task<OrderResponse> PlaceOrderAsync(OrderRequest request);
        Task<OrderResponse> ModifyOrderAsync(string orderId, OrderRequest request);
        Task CancelOrderAsync(string orderId);
        Task<OrderInfo> GetOrderAsync(string orderId);
        Task<OrderList> GetOrdersAsync(string accountKey);
        Task<PositionList> GetPositionsAsync(string accountKey);
    }
}
