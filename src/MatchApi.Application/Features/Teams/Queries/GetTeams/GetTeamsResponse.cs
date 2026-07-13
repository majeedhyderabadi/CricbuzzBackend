using MatchApi.Application.Features.Sport.Queries.GetSports;
using MatchApi.Domain.DTOs;

namespace MatchApi.Application.Features.Teams.Queries.GetTeams
{
    public class GetTeamsResponse
    {
        public Guid Id { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public Guid SportId { get; set; }

        public string Color { get; set; } = string.Empty;
        public GetSportResponse Sport { get; set; } = null!;

        public List<GetPlayerResponse> players { get; set; } = new List<GetPlayerResponse>();
    }
    public class GetSportResponse
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

    }
    public class GetPlayerResponse
    {
        public string PlayerName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public Guid PlayerId { get; set; }
        public Guid RoleId { get; set; }

    }

}
