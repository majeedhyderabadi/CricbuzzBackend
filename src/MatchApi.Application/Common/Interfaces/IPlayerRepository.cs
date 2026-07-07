using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface IPlayerRepository
{
    Task<Player?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
