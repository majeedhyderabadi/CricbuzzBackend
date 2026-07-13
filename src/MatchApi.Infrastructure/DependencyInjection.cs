using MatchApi.Application.Common.Interfaces;
using MatchApi.Infrastructure.Persistence;
using MatchApi.Infrastructure.Repositories;
using MatchApi.Infrastructure.Security;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace MatchApi.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("SqlServer")
            ?? throw new InvalidOperationException("Connection string 'SqlServer' is not configured.");

        services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(connectionString, sql =>
                sql.MigrationsAssembly(typeof(DependencyInjection).Assembly.FullName)));

        services.AddScoped<ITeamRepository, TeamRepository>();
        services.AddScoped<IFixtureRepository, FixtureRepository>();
        services.AddScoped<IPlayerRepository, PlayerRepository>(); 
        services.AddScoped<ISportRepository, SportRepository>();
        services.AddScoped<ISportRoleRepository, SportRoleRepository>();
        services.AddScoped<ICommentaryRepository, CommentaryRepository>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IAdminUserRepository, AdminUserRepository>();
        services.AddScoped<IJwtProvider, JwtProvider>();
        return services;
    }
}
