
using MatchApi.Domain.DTOs.Cricket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.ExternalMatches.Queries
{
    public class GetCricbuzzMatchInfoQueryHandler
     : IRequestHandler<GetCricbuzzMatchInfoQuery, TestMatchInfoDto?>
    {
        private readonly ICricbuzzService _cricbuzzService;

        public GetCricbuzzMatchInfoQueryHandler(ICricbuzzService cricbuzzService)
        {
            _cricbuzzService = cricbuzzService;
        }

        public async Task<TestMatchInfoDto?> Handle(
            GetCricbuzzMatchInfoQuery request,
            CancellationToken cancellationToken)
        {
            return await _cricbuzzService.GetMatchInfoAsync(
                request.MatchId,
                cancellationToken);
        }
    }
}
