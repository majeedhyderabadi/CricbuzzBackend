namespace MatchApi.Application.Features.Fixtures.Common;

public record TopPerformerDto(
    Guid PlayerId,
    string PlayerName,
    Guid TeamId,
    string TeamName,
    int RunsScored);
