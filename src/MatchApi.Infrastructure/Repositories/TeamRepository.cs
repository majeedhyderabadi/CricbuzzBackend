using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories;

public class TeamRepository : ITeamRepository
{
    private readonly ApplicationDbContext _context;

    public TeamRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task<Team?> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return _context.Teams.FirstOrDefaultAsync(t => t.Id == id, cancellationToken);
    }
}
