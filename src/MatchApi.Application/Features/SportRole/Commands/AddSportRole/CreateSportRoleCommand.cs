using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.SportRole.Commands.AddSportRole
{
    public class CreateSportRoleCommand
      : IRequest<CreateSportRoleResponse>
    {
        public Guid SportId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
