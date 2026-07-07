using MatchApi.Application.Features.Commentary.Common;

namespace MatchApi.Application.Common.Interfaces;

public interface ICommentaryBroadcaster
{
    Task BroadcastAsync(CommentaryDto commentary, CancellationToken cancellationToken);
}
