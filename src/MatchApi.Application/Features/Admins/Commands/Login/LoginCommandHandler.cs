using MatchApi.Application.Common.Interfaces;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace MatchApi.Application.Features.Admins.Commands.Login;

public class LoginCommandHandler
    : IRequestHandler<LoginCommand, LoginResponse>
{
    private readonly IAdminUserRepository _adminUserRepository;
    private readonly IJwtProvider _jwtProvider;

    public LoginCommandHandler(
        IAdminUserRepository adminUserRepository,
        IJwtProvider jwtProvider)
    {
        _adminUserRepository = adminUserRepository;
        _jwtProvider = jwtProvider;
    }

    public async Task<LoginResponse> Handle(
        LoginCommand request,
        CancellationToken cancellationToken)
    {
        var admin = await _adminUserRepository.GetByEmailAsync(
            request.Email,
            cancellationToken);

        if (admin is null)
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        if (!admin.IsApproved)
        {
            throw new InvalidOperationException("Admin account is not approved.");
        }

        var hash = Convert.ToBase64String(
            SHA256.HashData(
                Encoding.UTF8.GetBytes(
                    request.Password + admin.PasswordSalt)));

        if (hash != admin.PasswordHash)
        {
            throw new InvalidOperationException("Invalid email or password.");
        }

        var role = admin.IsSuperAdmin ? "SuperAdmin" : admin.IsApproved ? "Admin" : throw new InvalidOperationException("User does not have a valid admin role.");

        var token = _jwtProvider.GenerateToken(
            admin.Id,
            admin.Email,
            role);

        return new LoginResponse
        {
            Token = token,
            AdminId = admin.Id,
            FirstName = admin.FirstName,
            LastName = admin.LastName,
            Email = admin.Email,
            Role = role
        };
    }
}