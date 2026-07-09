using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Players.Commands.AddPlayers
{
    public class AddPlayerResponse
    {
        public Guid Id { get; set; }

        public string PlayerName { get; set; } = string.Empty;

        public Guid TeamId { get; set; }
    }
}
