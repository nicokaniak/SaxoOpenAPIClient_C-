using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IMessagesService : ISaxoService
    {
        Task<MessageList> GetMessagesAsync(string accountKey);
        Task<Message> GetMessageAsync(string messageId);
        Task<MessageSubscription> SubscribeToMessagesAsync(string accountKey);
        Task MarkMessageAsReadAsync(string messageId);
        Task DeleteMessageAsync(string messageId);
        Task<MessageResponse> SendMessageAsync(MessageRequest request);
    }
}
