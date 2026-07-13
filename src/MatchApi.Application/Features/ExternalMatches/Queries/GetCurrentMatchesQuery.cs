using MatchApi.Domain.DTOs.Cricket;
using MediatR;

namespace MatchApi.Application.Features.ExternalMatches.Queries;

public record GetCurrentMatchesQuery(int Offset = 0)
    : IRequest<CurrentMatchesResponse>;