using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries.SearchMatches;

public record SearchMatchesQuery(string SearchText)
    : IRequest<CricbuzzMatchListDto>;