using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;

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
}
