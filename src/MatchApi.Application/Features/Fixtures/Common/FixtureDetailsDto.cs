using MatchApi.Application.Features.Commentary.Common;

namespace MatchApi.Application.Features.Fixtures.Common;

public record FixtureDetailsDto(
    Guid Id,
    Guid HomeTeamId,
    string HomeTeamName,
    Guid AwayTeamId,
    string AwayTeamName,
    string Sport,
    DateTime ScheduledAtUtc,
    string Status,
    string? Phase,
    int HomeScore,
    int? HomeWickets,
    int AwayScore,
    int? AwayWickets,
    IReadOnlyList<CommentaryDto> Commentary,
    IReadOnlyList<TopPerformerDto> TopPerformers);
