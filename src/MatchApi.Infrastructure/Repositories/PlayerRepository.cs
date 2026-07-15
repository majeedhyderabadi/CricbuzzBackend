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
        return _context.Players.Include(x=>x.Team).FirstOrDefaultAsync(p => p.Id == id, cancellationToken);
    }
    public async Task AddAsync(
      Player player,
      CancellationToken cancellationToken)
    {
        await _context.Players.AddAsync(player, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }

    public async Task<bool> isPlayerExist(string playerName, Guid teamId,CancellationToken cancellationToken)
    {
        var player = await _context.Players.FirstOrDefaultAsync(s => s.Name.ToLower() == playerName.ToLower() && s.TeamId == teamId, cancellationToken);
        return player != null;

    }

    public async Task<List<Player>> GetPlayersByTeamIdAsync(
    Guid teamId,
    CancellationToken cancellationToken)
    {
        return await _context.Players
            .Where(x => x.TeamId == teamId).Include(x => x.SportRole)
            .OrderBy(x => x.Name)
            .ToListAsync(cancellationToken);
    }
    public async Task DeletePlayerAsync(Guid teamId, CancellationToken cancellationToken)
    {
        var player = await _context.Players
               .FirstOrDefaultAsync(
                   t => t.Id == teamId,
                   cancellationToken);

        if (player == null)
            throw new KeyNotFoundException("Team not found.");

        _context.Players.Remove(player);

        await _context.SaveChangesAsync(cancellationToken);
    }
    public async Task UpdatePlayerAsync(Player request, CancellationToken cancellationToken)
    {
        var playerToUpdate = await _context.Players
             .FirstOrDefaultAsync(
                 t => t.Id == request.Id,
                 cancellationToken);

        if (playerToUpdate == null)
            throw new KeyNotFoundException("Team not found.");

        playerToUpdate.Name = request.Name;
        playerToUpdate.TeamId = request.TeamId;
        playerToUpdate.SportRoleId = request.SportRoleId;


        await _context.SaveChangesAsync(cancellationToken);
    }
}
