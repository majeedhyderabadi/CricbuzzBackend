using MatchApi.Application.Features.Teams.Commands.CreateTeam;
using MatchApi.Domain.Enums;
using MediatR;

namespace MatchApi.Application.Features.Teams.Commands.CreateTeam;

public record CreateTeamCommand(
    string Name,
    Sport Sport,
    string ColorHex) : IRequest<CreateTeamResponse>;
