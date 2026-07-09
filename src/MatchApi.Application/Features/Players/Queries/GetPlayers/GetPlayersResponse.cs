using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Players.Queries.GetPlayers
{
    public class GetPlayersResponse
    {
        public Guid Id { get; set; }

        public Guid TeamId { get; set; }

        public string PlayerName { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;

    }
}
