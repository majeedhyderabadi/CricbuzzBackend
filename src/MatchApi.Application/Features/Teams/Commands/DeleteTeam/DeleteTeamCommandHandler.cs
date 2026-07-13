using MatchApi.Application.Common.Interfaces;
using MediatR;

namespace MatchApi.Application.Features.Teams.Commands.DeleteTeam
{
    public class DeleteTeamCommandHandler : IRequestHandler<DeleteTeamCommand>
    {
        private readonly ITeamRepository _repository;

        public DeleteTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task Handle(
            DeleteTeamCommand request,
            CancellationToken cancellationToken)
        {
            await _repository.DeleteTeamAsync(request.TeamId, cancellationToken);
        }
    }
}
