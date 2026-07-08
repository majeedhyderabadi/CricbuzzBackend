using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.Admins.Commands.RegisterAdmin;
using MatchApi.Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Admins.Commands.GetPendingApprovalRequests
{
    public class GetPendingApprovalRequestsQueryHandler
     : IRequestHandler<GetPendingApprovalRequestsQuery, List<PendingApprovalDto>>
    {
        private readonly IAdminUserRepository _adminUserRepository;

        public GetPendingApprovalRequestsQueryHandler(
            IAdminUserRepository adminUserRepository)
        {
            _adminUserRepository = adminUserRepository;
        }

        public async Task<List<PendingApprovalDto>> Handle(
            GetPendingApprovalRequestsQuery request,
            CancellationToken cancellationToken)
        {
            var admins = await _adminUserRepository.GetPendingApprovalRequestsAsync(cancellationToken);

            return admins.Select(admin => new PendingApprovalDto
            {
                Id = admin.Id,
                FirstName = admin.FirstName,
                LastName = admin.LastName,
                Email = admin.Email
            }).ToList();
        }
    }
}
