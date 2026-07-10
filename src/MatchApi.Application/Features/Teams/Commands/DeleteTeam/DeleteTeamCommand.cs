using MediatR;
namespace MatchApi.Application.Features.Teams.Commands.DeleteTeam;
public record DeleteTeamCommand(Guid TeamId) : IRequest;