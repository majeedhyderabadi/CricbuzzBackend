using MatchApi.Domain.DTOs;

namespace MatchApi.Application.Features.Teams.Queries.GetTeams
{
    public class GetTeamsResponse
    {
        public Guid Id { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public string Sport { get; set; } = string.Empty;

        public string Color { get; set; } = string.Empty;

        public List<PlayerDTO> players { get; set; } = new List<PlayerDTO>();
    }
}
