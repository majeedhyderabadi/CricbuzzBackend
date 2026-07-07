using Microsoft.AspNetCore.SignalR;

namespace MatchApi.Api.Hubs;

/// <summary>
/// Real-time channel for ball-by-ball commentary. Clients join a per-fixture group
/// to receive only the commentary relevant to the match they're viewing.
/// </summary>
public class CommentaryHub : Hub
{
    public const string CommentaryReceivedEvent = "CommentaryReceived";

    public Task JoinFixtureGroup(Guid fixtureId)
    {
        return Groups.AddToGroupAsync(Context.ConnectionId, GroupName(fixtureId));
    }

    public Task LeaveFixtureGroup(Guid fixtureId)
    {
        return Groups.RemoveFromGroupAsync(Context.ConnectionId, GroupName(fixtureId));
    }

    public static string GroupName(Guid fixtureId) => $"fixture-{fixtureId}";
}
