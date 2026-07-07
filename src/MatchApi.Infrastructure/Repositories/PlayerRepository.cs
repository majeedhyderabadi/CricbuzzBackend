using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApplicationDbContext _context;

    public PlayerRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Player?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Players.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
}
