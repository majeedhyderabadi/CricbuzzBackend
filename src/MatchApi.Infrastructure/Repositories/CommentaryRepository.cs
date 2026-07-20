using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories;

public class CommentaryRepository : ICommentaryRepository
{
    private readonly ApplicationDbContext _context;

    public CommentaryRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(CommentaryEntry entry, CancellationToken cancellationToken)
    {
        await _context.CommentaryEntries.AddAsync(entry, cancellationToken);
    }

    public async Task<IReadOnlyList<CommentaryEntry>> GetByFixtureIdAsync(Guid fixtureId, CancellationToken cancellationToken)
    {
        return await _context.CommentaryEntries
            .AsNoTracking()
            .Include(c => c.Player)
                .ThenInclude(p => p!.Team)
            .Where(c => c.FixtureId == fixtureId)
            .ToListAsync(cancellationToken);
    }
}
