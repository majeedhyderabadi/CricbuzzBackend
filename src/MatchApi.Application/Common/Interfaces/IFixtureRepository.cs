using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface IFixtureRepository
{
    Task AddAsync(Fixture fixture, CancellationToken cancellationToken);
}
