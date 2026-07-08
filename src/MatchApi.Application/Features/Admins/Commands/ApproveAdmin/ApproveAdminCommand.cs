using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Admins.Commands.ApproveAdmin
{
    public record ApproveAdminCommand(Guid AdminId) : IRequest;
}
