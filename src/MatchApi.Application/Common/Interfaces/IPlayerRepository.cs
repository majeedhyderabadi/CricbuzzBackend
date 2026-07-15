using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface IPlayerRepository
{
    Task<Player?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task AddAsync(Player player, CancellationToken cancellationToken);
    Task<List<Player>> GetPlayersByTeamIdAsync(
     Guid teamId,
     CancellationToken cancellationToken);
    Task DeletePlayerAsync(Guid teamId, CancellationToken cancellationToken);
    Task UpdatePlayerAsync(Player request, CancellationToken cancellationToken);
    Task<bool> isPlayerExist(string playerName, Guid teamId, CancellationToken cancellationToken);
}
