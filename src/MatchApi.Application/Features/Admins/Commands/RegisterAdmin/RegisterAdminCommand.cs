using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Application.Features.Admins.Commands.RegisterAdmin;

public record RegisterAdminCommand(
    string FirstName,
    string LastName,
    string Email,
    string Password
) : IRequest<Guid>;

public record GetPendingApprovalRequestsQuery()
    : IRequest<List<PendingApprovalDto>>;