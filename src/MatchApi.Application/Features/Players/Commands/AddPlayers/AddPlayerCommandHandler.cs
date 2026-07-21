using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MatchApi.Domain.Entities;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.AddPlayers
{
    public class AddPlayerCommandHandler
     : IRequestHandler<AddPlayerCommand, ResponseResult<string>>
    {
        private readonly IPlayerRepository _repository;
        private readonly ITeamRepository _teamRepository;

        public AddPlayerCommandHandler(IPlayerRepository repository, ITeamRepository teamRepository)
        {
            _repository = repository;
            _teamRepository = teamRepository;
        }

        public async Task<ResponseResult<string>> Handle(
            AddPlayerCommand request,
            CancellationToken cancellationToken)
        {
            if(await _repository.isPlayerExist(request.PlayerName, request.TeamId, cancellationToken))
            {
                return new ResponseResult<string>
                {
                    Success = false,
                    Message = "Player already exists for the given team."
                };
            }

            var team = await _teamRepository.GetByIdAsync(request.TeamId, cancellationToken);
            if (team != null && team.Sport.Name.ToLower() == "cricket" && team.Players.Count > 11)
                return new ResponseResult<string>
                {
                    Success = false,
                    Message = "Maximum Players Reached. A team can have a maximum of 11 players."
                };

            var player = new Player
            {
                Id = Guid.NewGuid(),
                TeamId = request.TeamId,
                Name = request.PlayerName,
                SportRoleId = request.SportRoleId
            };

            await _repository.AddAsync(player, cancellationToken);

            return new ResponseResult<string>
            {
                Success = true,
                Message = "Player added successfully."
            };
        }
    }
}
