using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface ITeamRepository
{
    Task AddAsync(Team fixture, CancellationToken cancellationToken);
    Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Team>> GetTeamsAsync(CancellationToken cancellationToken);
}
