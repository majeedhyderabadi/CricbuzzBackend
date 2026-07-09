using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public TeamRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }
    public async Task AddAsync(Team team, CancellationToken cancellationToken)
    {
        await _context.Teams.AddAsync(team, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
    public Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Teams.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
    public async Task<List<Team>> GetTeamsAsync(CancellationToken cancellationToken)
    {
        return await _context.Teams
            .OrderBy(t => t.Name).Include(t => t.Players)
            .ToListAsync(cancellationToken);
    }
}
