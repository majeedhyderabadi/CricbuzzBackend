using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface IAdminUserRepository
{
    Task<AdminUser?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken);

    Task AddAsync(
        AdminUser adminUser,
        CancellationToken cancellationToken);
}