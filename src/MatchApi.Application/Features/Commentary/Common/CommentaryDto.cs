namespace MatchApi.Application.Features.Commentary.Common;

public record CommentaryDto(
    Guid Id,
    Guid FixtureId,
    string Side,
    Guid PlayerId,
    string PlayerName,
    string Action,
    string? Note,
    DateTime CreatedAtUtc,
    int HomeScore,
    int? HomeWickets,
    int AwayScore,
    int? AwayWickets);
