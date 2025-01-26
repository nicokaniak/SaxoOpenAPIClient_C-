using System;
using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface ITradesService : ISaxoService
    {
        Task<TradeList> GetTradesAsync(string accountKey);
        Task<Trade> GetTradeAsync(string tradeId);
        Task<TradeSubscription> SubscribeToTradesAsync(string accountKey);
        Task<TradeHistory> GetTradeHistoryAsync(string accountKey, DateTime from, DateTime to);
        Task<TradeDetails> GetTradeDetailsAsync(string tradeId);
        Task<TradeCorrection> CorrectTradeAsync(string tradeId, TradeCorrectionRequest request);
    }
}
