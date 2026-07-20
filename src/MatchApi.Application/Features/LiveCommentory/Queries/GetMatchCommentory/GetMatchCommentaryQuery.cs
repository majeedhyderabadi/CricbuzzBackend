using MatchApi.Domain.DTOs.Commentary;
using MediatR;

namespace MatchApi.Application.Features.LiveCommentary.Queries.GetMatchCommentary;

public record GetMatchCommentaryQuery(int CricbuzzMatchId)
    : IRequest<MatchCommentaryResponseDto>;