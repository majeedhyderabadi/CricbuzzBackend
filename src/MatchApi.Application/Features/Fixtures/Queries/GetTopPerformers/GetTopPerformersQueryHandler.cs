using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.Fixtures.Common;
using MatchApi.Domain.Enums;
using MediatR;

namespace MatchApi.Application.Features.Fixtures.Queries.GetTopPerformers;

public class GetTopPerformersQueryHandler : IRequestHandler<GetTopPerformersQuery, IReadOnlyList<TopPerformerDto>>
{
    private const int TopPerformerCount = 4;

    private readonly IFixtureRepository _fixtureRepository;
    private readonly ICommentaryRepository _commentaryRepository;

    public GetTopPerformersQueryHandler(IFixtureRepository fixtureRepository, ICommentaryRepository commentaryRepository)
    {
        _fixtureRepository = fixtureRepository;
        _commentaryRepository = commentaryRepository;
    }

    public async Task<IReadOnlyList<TopPerformerDto>> Handle(GetTopPerformersQuery request, CancellationToken cancellationToken)
    {
        _ = await _fixtureRepository.GetByIdAsync(request.FixtureId, cancellationToken)
            ?? throw new InvalidOperationException("Fixture not found.");

        var entries = await _commentaryRepository.GetByFixtureIdAsync(request.FixtureId, cancellationToken);

        // Grouped by the scalar PlayerId (not the Player navigation) because entries are loaded
        // AsNoTracking without identity resolution: each row materializes its own Player instance,
        // so grouping by the object itself would split one player's entries across several groups.
        return entries
            .Where(e => e.PlayerId is not null && e.Player is not null)
            .GroupBy(e => e.PlayerId!.Value)
            .Select(g =>
            {
                var player = g.First().Player!;
                return new TopPerformerDto(
                    player.Id,
                    player.Name,
                    player.TeamId,
                    player.Team?.Name ?? string.Empty,
                    g.Sum(e => e.Action.ToRuns()));
            })
            .OrderByDescending(p => p.RunsScored)
            .Take(TopPerformerCount)
            .ToList();
    }
}
