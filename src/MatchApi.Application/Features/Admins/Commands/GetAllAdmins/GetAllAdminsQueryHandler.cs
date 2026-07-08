using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;


namespace MatchApi.Application.Features.Admins.Commands.GetAllAdmins
{
    public class GetAllAdminsQueryHandler
     : IRequestHandler<GetAllAdminsQuery, List<AdminUserDto>>
    {
        private readonly IAdminUserRepository _adminUserRepository;

        public GetAllAdminsQueryHandler(IAdminUserRepository adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }

        public async Task<List<AdminUserDto>> Handle(
            GetAllAdminsQuery request,
            CancellationToken cancellationToken)
        {
            var admins = await _adminUserRepository.GetAllAsync(cancellationToken);

            return admins.Select(admin => new AdminUserDto
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email,
                IsApproved = admin.IsApproved
            }).ToList();
        }
    }
}
