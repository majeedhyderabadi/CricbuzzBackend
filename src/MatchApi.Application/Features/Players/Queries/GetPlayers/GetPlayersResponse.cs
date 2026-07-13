
using MatchApi.Domain.Entities;

namespace MatchApi.Application.Features.Players.Queries.GetPlayers
{
    public class GetPlayersResponse
    {
        public Guid Id { get; set; }
        public Guid TeamId { get; set; }
        public Guid SportRoleId { get; set; }
        public string PlayerName { get; set; } = string.Empty;  
        public SportRoleResponse SportRole { get; set; } = null!;
    }

    public class SportRoleResponse
    {   
        public string RoleName { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
