using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MediatR;

namespace MatchApi.Application.Features.Admins.Commands.ApproveAdmin
{
    public class ApproveAdminCommandHandler : IRequestHandler<ApproveAdminCommand>
    {
        private readonly IAdminUserRepository _adminUserRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ApproveAdminCommandHandler(
            IAdminUserRepository adminUserRepository,
            IUnitOfWork unitOfWork)
        {
            _adminUserRepository = adminUserRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(
            ApproveAdminCommand request,
            CancellationToken cancellationToken)
        {
            var admin = await _adminUserRepository.GetByIdAsync(
                request.AdminId,
                cancellationToken);

            if (admin is null)
            {
                throw new InvalidOperationException("Admin user not found.");
            }

            admin.Approve();

            _adminUserRepository.Update(admin);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
        }
    }
}
