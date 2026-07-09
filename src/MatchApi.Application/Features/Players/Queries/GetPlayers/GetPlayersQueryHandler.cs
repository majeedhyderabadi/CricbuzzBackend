using MatchApi.Application.Common.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Players.Queries.GetPlayers
{
    public class GetPlayersQueryHandler
     : IRequestHandler<GetPlayersQuery, List<GetPlayersResponse>>
    {
        private readonly IPlayerRepository _repository;

        public GetPlayersQueryHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<GetPlayersResponse>> Handle(
            GetPlayersQuery request,
            CancellationToken cancellationToken)
        {
            var players = await _repository.GetPlayersByTeamIdAsync(
                request.TeamId,
                cancellationToken);

            return players.Select(player => new GetPlayersResponse
            {
                Id = player.Id,
                TeamId = player.TeamId,
                PlayerName = player.Name,
                Role = player.Role
            }).ToList();
        }
    }
}
