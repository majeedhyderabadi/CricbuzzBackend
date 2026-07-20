using System.Net.Http.Json;
using System.Text.RegularExpressions;
using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Commentary;

namespace MatchApi.Infrastructure.Services;

public class CricbuzzCommentaryService : ICricbuzzCommentaryService
{
    private readonly HttpClient _httpClient;

    public CricbuzzCommentaryService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<MatchCommentaryResponseDto> GetCommentaryAsync(
        int cricbuzzMatchId,
        CancellationToken cancellationToken = default)
    {
        var allInnings = new List<CommentaryInningsDto>();

        // T20/ODI me generally 2 innings,
        // Test match me maximum 4 innings.
        for (var inningsId = 1; inningsId <= 4; inningsId++)
        {
            var url =
                $"api/mcenter/{cricbuzzMatchId}/full-commentary/{inningsId}";

            try
            {
                var response =
                    await _httpClient.GetFromJsonAsync<CricbuzzCommentaryResponse>(
                        url,
                        cancellationToken);

                if (response?.Commentary is null ||
                    response.Commentary.Count == 0)
                {
                    continue;
                }

                var innings = response.Commentary
                    .Select(x => new CommentaryInningsDto
                    {
                        InningsId = x.InningsId,

                        Commentary = x.CommentaryList

                            // Empty commentary hatao
                            .Where(item =>
                                !string.IsNullOrWhiteSpace(item.CommText))

                            // Apne clean DTO me map karo
                            .Select(item => new CommentaryDto
                            {
                                OverNumber = item.OverNumber,
                                BallNumber = item.BallNbr,
                                InningsId = item.InningsId,

                                Commentary = CleanCommentaryText(
                                    item.CommText!),

                                Event = item.Event,
                                BattingTeam = item.BatTeamName,

                                Score = item.BatTeamScore,

                                BatsmanName =
                                    item.BatsmanStriker?.BatName,

                                BowlerName =
                                    item.BowlerStriker?.BowlName,

                                Timestamp = item.Timestamp
                            })

                            // Cleaning ke baad empty ho to hatao
                            .Where(item =>
                                !string.IsNullOrWhiteSpace(item.Commentary))

                            // Duplicate commentary hatao
                            .DistinctBy(item => new
                            {
                                item.InningsId,
                                item.BallNumber,
                                item.Timestamp,
                                item.Commentary
                            })

                            // Latest commentary first
                            .OrderByDescending(item =>
                                item.Timestamp)

                            .ToList()
                    })

                    // Sirf requested innings ko rakho
                    .Where(x =>
                        x.InningsId == inningsId &&
                        x.Commentary.Count > 0)

                    .ToList();

                allInnings.AddRange(innings);
            }
            catch (HttpRequestException)
            {
                // Agar koi innings available nahi hai,
                // to next innings try karo.
                continue;
            }
        }

        // Safety: same innings multiple baar aa jaye to merge/deduplicate.
        var finalInnings = allInnings
            .GroupBy(x => x.InningsId)
            .Select(group => new CommentaryInningsDto
            {
                InningsId = group.Key,

                Commentary = group
                    .SelectMany(x => x.Commentary)

                    .DistinctBy(item => new
                    {
                        item.InningsId,
                        item.BallNumber,
                        item.Timestamp,
                        item.Commentary
                    })

                    .OrderByDescending(item =>
                        item.Timestamp)

                    .ToList()
            })

            // Latest innings first
            .OrderByDescending(x =>
                x.InningsId)

            .ToList();

        return new MatchCommentaryResponseDto
        {
            MatchId = cricbuzzMatchId,
            Innings = finalInnings
        };
    }

    private static string CleanCommentaryText(string text)
    {
        if (string.IsNullOrWhiteSpace(text))
            return string.Empty;

        // B0$, B1$, B2$ etc.
        text = Regex.Replace(
            text,
            @"B\d+\$",
            string.Empty);

        // I0$, I1$, I2$ etc.
        text = Regex.Replace(
            text,
            @"I\d+\$",
            string.Empty);

        // Escaped new lines
        text = text.Replace(
            @"\n",
            Environment.NewLine);

        // Multiple spaces -> single space
        text = Regex.Replace(
            text,
            @"[ \t]+",
            " ");

        // Maximum 2 consecutive new lines
        text = Regex.Replace(
            text,
            @"(\r?\n){3,}",
            Environment.NewLine + Environment.NewLine);

        return text.Trim();
    }
}