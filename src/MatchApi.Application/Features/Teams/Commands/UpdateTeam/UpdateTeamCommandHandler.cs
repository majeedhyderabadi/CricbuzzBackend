using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.Entities;
using MediatR;

namespace MatchApi.Application.Features.Teams.Commands.UpdateTeam
{
    public class UpdateTeamCommandHandler
    : IRequestHandler<UpdateTeamCommand, bool>
    {
        private readonly ITeamRepository _repository;

        public UpdateTeamCommandHandler(ITeamRepository repository)
        {
            _repository = repository;
        }

        public async Task<bool> Handle(
            UpdateTeamCommand request,
            CancellationToken cancellationToken)
        {
            try
            {
                Team updatedTeam = new Team
                {
                    Id = request.Id,
                    Name = request.Name,
                    SportId = request.SportId,
                    ColorHex = request.ColorHex
                };
                await _repository.UpdateTeamAsync(updatedTeam, cancellationToken);

                return true;
            }
            catch (Exception ex)
            {

                return false;
            }
        }
    }
}
