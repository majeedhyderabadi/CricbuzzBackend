using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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

    public Task<Fixture?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Fixtures.FirstOrDefaultAsync(f => f.Id == id, cancellationToken);
    }
}
