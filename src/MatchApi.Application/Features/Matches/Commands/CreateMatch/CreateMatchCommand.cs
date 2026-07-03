using MediatR;

namespace MatchApi.Application.Features.Matches.Commands.CreateMatch;

public record CreateMatchCommand(
    string HomeTeam,
    string AwayTeam,
    DateTime MatchDateUtc,
    string Venue) : IRequest<CreateMatchResponse>;
