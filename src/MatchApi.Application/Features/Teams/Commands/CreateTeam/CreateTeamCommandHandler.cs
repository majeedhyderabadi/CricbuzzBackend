using MatchApi.Application.Common.Interfaces;
using MediatR;
using Team = MatchApi.Domain.Entities.Team;

namespace MatchApi.Application.Features.Teams.Commands.CreateTeam;

public class CreateTeamCommandHandler : IRequestHandler<CreateTeamCommand, CreateTeamResponse>
{
    private readonly ITeamRepository _teamRepository;

    public CreateTeamCommandHandler(
        ITeamRepository teamRepository)
    {
        _teamRepository = teamRepository;
    }

    public async Task<CreateTeamResponse> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var team = Team.Create(request.Name, request.SportId, request.ColorHex);
            await _teamRepository.AddAsync(team, cancellationToken);
            return new CreateTeamResponse(
                team.Id,
                team.Name,
                team.SportId,
                team.ColorHex);
        }
        catch (Exception ex)
        {

            throw;
        }
    }
}

