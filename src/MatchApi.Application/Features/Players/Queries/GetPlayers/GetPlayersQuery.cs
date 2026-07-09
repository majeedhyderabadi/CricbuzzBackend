using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Players.Queries.GetPlayers;

public record GetPlayersQuery(Guid TeamId)
    : IRequest<List<GetPlayersResponse>>;
