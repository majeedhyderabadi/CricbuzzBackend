using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.AddPlayers
{
    public class AddPlayerCommand : IRequest<ResponseResult<string>>
    {
        public Guid TeamId { get; set; }

        public string PlayerName { get; set; } = string.Empty;

        public Guid SportRoleId { get; set; }
    }
}
