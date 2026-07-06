using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;

namespace MatchApi.Infrastructure.Repositories;

public class FixtureRepository : IFixtureRepository
{
    private readonly ApplicationDbContext _context;

    public FixtureRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Fixture fixture, CancellationToken cancellationToken)
    {
        await _context.Fixtures.AddAsync(fixture, cancellationToken);
    }
}
