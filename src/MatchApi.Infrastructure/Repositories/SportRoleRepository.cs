using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories
{
    public class SportRoleRepository : ISportRoleRepository
    {
        private readonly ApplicationDbContext _context;
        private readonly IUnitOfWork _unitOfWork;
        public SportRoleRepository(ApplicationDbContext context, IUnitOfWork unitOfWork)
        {
            _context = context;
            _unitOfWork = unitOfWork;
        }

        public async Task AddSportRoleAsync(
           SportRole sportRole,
          CancellationToken cancellationToken)
        {
            await _context.SportRoles.AddAsync(sportRole, cancellationToken);
            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
        public async Task<List<SportRole>> GetSportRolesAsync(CancellationToken cancellationToken)
        {
            return await _context.SportRoles
                .OrderBy(t => t.RoleName).Include(t => t.Sport)
                .ToListAsync<SportRole>(cancellationToken);

        }
        public async Task<List<SportRole>> GetSportRolesBySportIdAsync(
            Guid sportId,
            CancellationToken cancellationToken)
        {
            return await _context.SportRoles
                .Where(x => x.SportId == sportId).Include(x => x.Sport)
                .OrderBy(x => x.RoleName)
                .ToListAsync(cancellationToken);
        }

        public async Task<bool> isSportRoleExixst(
        Guid sportId,
        string roleName,
        CancellationToken cancellationToken)
        {
            var role = await _context.SportRoles
                .FirstOrDefaultAsync(x => x.SportId == sportId && x.RoleName.ToLower() == roleName.ToLower(), cancellationToken);
            return role != null;
        }
    }
}
