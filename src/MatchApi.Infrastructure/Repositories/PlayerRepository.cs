using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories;

public class PlayerRepository : IPlayerRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public PlayerRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public Task<Player?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Players.FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
    public async Task AddAsync(
      Player player,
      CancellationToken cancellationToken)
    {
        await _context.Players.AddAsync(player, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<List<Player>> GetPlayersByTeamIdAsync(
    Guid teamId,
    CancellationToken cancellationToken)
    {
        return await _context.Players
            .Where(x => x.TeamId == teamId)
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
}
