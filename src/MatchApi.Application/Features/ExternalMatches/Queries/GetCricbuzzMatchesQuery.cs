using MatchApi.Domain.DTOs.Cricket;
using MediatR;

public record GetCricbuzzMatchesQuery
    : IRequest<CricbuzzMatchListDto?>;