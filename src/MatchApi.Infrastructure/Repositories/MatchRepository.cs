using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;

namespace MatchApi.Infrastructure.Repositories;

public class MatchRepository : IMatchRepository
{
    private readonly ApplicationDbContext _context;

    public MatchRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(Match match, CancellationToken cancellationToken)
    {
        await _context.Matches.AddAsync(match, cancellationToken);
    }
}
