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
}