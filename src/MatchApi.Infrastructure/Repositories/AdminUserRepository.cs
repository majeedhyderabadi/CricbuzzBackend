using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MatchApi.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace MatchApi.Infrastructure.Repositories;

public class AdminUserRepository : IAdminUserRepository
{
    private readonly ApplicationDbContext _context;

    public AdminUserRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<AdminUser?> GetByEmailAsync(
        string email,
        CancellationToken cancellationToken)
    {
        return await _context.AdminUsers
            .FirstOrDefaultAsync(
                x => x.Email == email,
                cancellationToken);
    }

    public async Task AddAsync(
        AdminUser adminUser,
        CancellationToken cancellationToken)
    {
        await _context.AdminUsers.AddAsync(
            adminUser,
            cancellationToken);
    }

    public async Task<IEnumerable<AdminUser>> GetPendingApprovalsAsync()
    {
        return await _context.AdminUsers
            .Where(x => !x.IsApproved)
            .ToListAsync();
    }

    public async Task ApproveAdminAsync(Guid adminUserId)
    {
        var admin = await _context.AdminUsers
            .FirstOrDefaultAsync(x => x.Id == adminUserId);

        if (admin == null)
            throw new Exception("Admin user not found.");

        if (admin.IsApproved)
            throw new Exception("Admin user is already approved.");

        admin.IsApproved = true;

        await _context.SaveChangesAsync();
    }

    public async Task<AdminUser?> GetByIdAsync(
     Guid id,
     CancellationToken cancellationToken)
    {
        return await _context.AdminUsers
            .FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
    }

    public void Update(AdminUser adminUser)
    {
        _context.AdminUsers.Update(adminUser);
    }
    public async Task<List<AdminUser>> GetPendingApprovalRequestsAsync(
    CancellationToken cancellationToken)
    {
        return await _context.AdminUsers
            .Where(x => !x.IsApproved)
            .OrderBy(x => x.FirstName)
            .ToListAsync(cancellationToken);
    }

    public async Task<List<AdminUser>> GetAllAsync(
    CancellationToken cancellationToken)
    {
        return await _context.AdminUsers
            .OrderBy(x => x.FirstName)
            .ThenBy(x => x.LastName)
            .ToListAsync(cancellationToken);
    }
}