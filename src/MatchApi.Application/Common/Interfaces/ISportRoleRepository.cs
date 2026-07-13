using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces
{
    public interface ISportRoleRepository
    {
        Task AddSportRoleAsync(
    SportRole sportRole,
    CancellationToken cancellationToken);
        Task<List<SportRole>> GetSportRolesAsync(CancellationToken cancellationToken);
        Task<List<SportRole>> GetSportRolesBySportIdAsync(
            Guid sportId,
            CancellationToken cancellationToken);
    }
}
