using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface ITeamRepository
{
    Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
