using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MediatR;
using System.Security.Cryptography;
using System.Text;

namespace MatchApi.Application.Features.Admins.Commands.RegisterAdmin;

public class RegisterAdminCommandHandler
    : IRequestHandler<RegisterAdminCommand, Guid>
{
    private readonly IAdminUserRepository _adminUserRepository;
    private readonly IUnitOfWork _unitOfWork;

    public RegisterAdminCommandHandler(
        IAdminUserRepository adminUserRepository,
        IUnitOfWork unitOfWork)
    {
        _adminUserRepository = adminUserRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<Guid> Handle(
        RegisterAdminCommand request,
        CancellationToken cancellationToken)
    {
        var existingAdmin =
            await _adminUserRepository.GetByEmailAsync(
                request.Email,
                cancellationToken);

        if (existingAdmin != null)
        {
            throw new InvalidOperationException(
                "Email already exists.");
        }

        var salt = Guid.NewGuid().ToString();

        var hash = Convert.ToBase64String(
            SHA256.HashData(
                Encoding.UTF8.GetBytes(
                    request.Password + salt)));

        var admin = AdminUser.Create(
            request.FirstName,
            request.LastName,
            request.Email,
            hash,
            salt);

        await _adminUserRepository.AddAsync(
            admin,
            cancellationToken);

        await _unitOfWork.SaveChangesAsync(
            cancellationToken);

        return admin.Id;
    }
}