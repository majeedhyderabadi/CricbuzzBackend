using MatchApi.Domain.DTOs.Cricket;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Common.Interfaces;

public interface ICricApiService
{
    Task<CurrentMatchesResponse> GetCurrentMatchesAsync(
        int offset = 0,
        CancellationToken cancellationToken = default);

    Task<MatchDetailsResponse> GetMatchDetailsAsync(
       string matchId,
       CancellationToken cancellationToken = default);
}
