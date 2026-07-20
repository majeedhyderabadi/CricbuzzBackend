using MediatR;
using MatchApi.Domain.DTOs.Cricket;

namespace MatchApi.Application.Features.ExternalMatches.Queries.GetMatchDetails;

public record GetMatchDetailsQuery(string MatchId)
    : IRequest<MatchDetailsResponse>;