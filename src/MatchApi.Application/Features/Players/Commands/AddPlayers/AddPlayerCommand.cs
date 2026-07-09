using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Players.Commands.AddPlayers
{
    public class AddPlayerCommand : IRequest<AddPlayerResponse>
    {
        public Guid TeamId { get; set; }

        public string PlayerName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}
