using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface IMatchRepository
{
    Task AddAsync(Match match, CancellationToken cancellationToken);
}
