using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MediatR;

namespace MatchApi.Application.Features.Players.Commands.AddPlayers
{
    public class AddPlayerCommandHandler
     : IRequestHandler<AddPlayerCommand, AddPlayerResponse>
    {
        private readonly IPlayerRepository _repository;

        public AddPlayerCommandHandler(IPlayerRepository repository)
        {
            _repository = repository;
        }

        public async Task<AddPlayerResponse> Handle(
            AddPlayerCommand request,
            CancellationToken cancellationToken)
        {
            var player = new Player
            {
                Id = Guid.NewGuid(),
                TeamId = request.TeamId,
                Name = request.PlayerName,
                SportRoleId = request.SportRoleId
            };

            await _repository.AddAsync(player, cancellationToken);

            return new AddPlayerResponse
            {
                Id = player.Id,
                TeamId = player.TeamId,
                PlayerName = player.Name,
                SportRoleId = player.SportRoleId
            };
        }
    }
}
