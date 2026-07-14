using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries.GetCricbuzzScorecard;

public record GetCricbuzzScorecardQuery(
    long MatchId
) : IRequest<CricbuzzScorecardResponseDto?>;