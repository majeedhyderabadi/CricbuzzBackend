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

    Task<IEnumerable<AdminUser>> GetPendingApprovalsAsync();
    Task ApproveAdminAsync(Guid adminUserId);
    Task<AdminUser?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    void Update(AdminUser adminUser);
    Task<List<AdminUser>> GetPendingApprovalRequestsAsync(CancellationToken cancellationToken);
    Task<List<AdminUser>> GetAllAsync(CancellationToken cancellationToken);
}