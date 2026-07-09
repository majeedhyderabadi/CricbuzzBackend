using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;

namespace MatchApi.Application.Features.Teams.Queries.GetTeams
{
    public class GetTeamsQueryHandler
     : IRequestHandler<GetTeamsQuery, List<GetTeamsResponse>>
    {
        private readonly ITeamRepository _repository;

        public GetTeamsQueryHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetTeamsResponse>> Handle(
            GetTeamsQuery request,
            CancellationToken cancellationToken)
        {
            var teams = await _repository.GetTeamsAsync(cancellationToken);

            return teams.Select(team => new GetTeamsResponse
            {
                Id = team.Id,
                TeamName = team.Name,
                Sport = team.Sport.ToString(),
                Color = team.ColorHex,
                players = team.Players.Select(player => new PlayerDTO
                {
                    Role = player.Role,
                    Name = player.Name
                }).ToList()
            }).ToList();
        }
    }
}
