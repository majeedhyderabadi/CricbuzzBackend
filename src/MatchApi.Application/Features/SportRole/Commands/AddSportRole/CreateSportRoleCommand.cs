using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Application.Features.SportRole.Commands.AddSportRole
{
    public class CreateSportRoleCommand
      : IRequest<ResponseResult<string>>
    {
        public Guid SportId { get; set; }
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
