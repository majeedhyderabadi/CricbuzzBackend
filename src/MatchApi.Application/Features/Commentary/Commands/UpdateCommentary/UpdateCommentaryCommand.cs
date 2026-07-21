using MatchApi.Application.Features.Commentary.Common;
using MediatR;

namespace MatchApi.Application.Features.Commentary.Commands.UpdateCommentary;

public record UpdateCommentaryCommand(Guid FixtureId, Guid CommentaryId, string? Note) : IRequest<CommentaryDto>;
