using MatchApi.Domain.DTOs.Cricket;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.ExternalMatches.Queries
{
    public record GetCricbuzzMatchInfoQuery(long MatchId)
     : IRequest<TestMatchInfoDto?>;
}
