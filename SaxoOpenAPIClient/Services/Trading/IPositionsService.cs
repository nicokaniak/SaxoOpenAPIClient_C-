using System.Threading.Tasks;
using SaxoOpenAPIClient.Services.Trading.Models;

namespace SaxoOpenAPIClient.Services.Trading
{
    public interface IPositionsService : ISaxoService
    {
        Task<PositionList> GetPositionsAsync(string accountKey);
        Task<Position> GetPositionAsync(string positionId);
        Task<PositionSubscription> SubscribeToPositionsAsync(string accountKey);
        Task<NetPositionList> GetNetPositionsAsync(string accountKey);
        Task<PositionMarginImpact> GetMarginImpactAsync(string positionId);
        Task<PositionExercise> ExercisePositionAsync(string positionId, PositionExerciseRequest request);
        Task<PositionRollover> RolloverPositionAsync(string positionId, PositionRolloverRequest request);
    }
}
