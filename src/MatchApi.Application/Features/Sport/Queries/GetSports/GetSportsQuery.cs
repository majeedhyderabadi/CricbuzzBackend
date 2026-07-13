using MediatR;

namespace MatchApi.Application.Features.Sport.Queries.GetSports
{
    public record GetSportsQuery()
      : IRequest<List<GetSportsResponse>>;
}
