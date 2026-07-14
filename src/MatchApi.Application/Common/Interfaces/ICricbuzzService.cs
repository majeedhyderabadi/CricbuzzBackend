using MatchApi.Domain.DTOs.Cricket;

public interface ICricbuzzService
{
    Task<CricbuzzMatchListDto?> GetMatchesAsync();
    Task<TestMatchInfoDto?> GetMatchInfoAsync(
     long matchId,
     CancellationToken cancellationToken);
}