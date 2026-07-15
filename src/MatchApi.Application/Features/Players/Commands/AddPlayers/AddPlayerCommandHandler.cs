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

        public AddPlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
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
