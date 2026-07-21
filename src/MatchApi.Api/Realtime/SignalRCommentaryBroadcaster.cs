using MatchApi.Api.Hubs;
using MatchApi.Application.Common.Interfaces;
using MatchApi.Application.Features.Commentary.Common;
using Microsoft.AspNetCore.SignalR;

namespace MatchApi.Api.Realtime;

/// <summary>
/// Adapter that fulfils the application layer's <see cref="ICommentaryBroadcaster"/> port
/// using SignalR, pushing new commentary to clients subscribed to the fixture's group.
/// </summary>
public class SignalRCommentaryBroadcaster : ICommentaryBroadcaster
{
    private readonly IHubContext<CommentaryHub> _hubContext;

    public SignalRCommentaryBroadcaster(IHubContext<CommentaryHub> hubContext)
    {
        _hubContext = hubContext;
    }

    public Task BroadcastAsync(CommentaryDto commentary, CancellationToken cancellationToken)
    {
        return _hubContext.Clients
            .Group(CommentaryHub.GroupName(commentary.FixtureId))
            .SendAsync(CommentaryHub.CommentaryReceivedEvent, commentary, cancellationToken);
    }

    public Task BroadcastUpdateAsync(CommentaryDto commentary, CancellationToken cancellationToken)
    {
        return _hubContext.Clients
            .Group(CommentaryHub.GroupName(commentary.FixtureId))
            .SendAsync(CommentaryHub.CommentaryUpdatedEvent, commentary, cancellationToken);
    }
}
