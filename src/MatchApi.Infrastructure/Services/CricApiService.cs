using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs.Cricket;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Json;

namespace MatchApi.Infrastructure.Services;

public class CricApiService : ICricApiService
{
    private readonly HttpClient _httpClient;
    private readonly IConfiguration _configuration;

    public CricApiService(
        HttpClient httpClient,
        IConfiguration configuration)
    {
        _httpClient = httpClient;
        _configuration = configuration;
    }

    public async Task<CurrentMatchesResponse> GetCurrentMatchesAsync(
        int offset = 0,
        CancellationToken cancellationToken = default)
    {
        var apiKey = _configuration["CricApi:ApiKey"];

        var url = $"currentMatches?apikey={apiKey}&offset={offset}";

        var response = await _httpClient.GetFromJsonAsync<CurrentMatchesResponse>(
            url,
            cancellationToken);

        return response ?? new CurrentMatchesResponse();
    }

    public async Task<MatchDetailsResponse> GetMatchDetailsAsync(
      string matchId,
      CancellationToken cancellationToken = default)
    {
        var apiKey = _configuration["CricApi:ApiKey"];

        var url = $"match_scorecard?apikey={apiKey}&id={matchId}";

        var response = await _httpClient.GetFromJsonAsync<MatchDetailsResponse>(
            url,
            cancellationToken);

        return response ?? new MatchDetailsResponse();
    }
}