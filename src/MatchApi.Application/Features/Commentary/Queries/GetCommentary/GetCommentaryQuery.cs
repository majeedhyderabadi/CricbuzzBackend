using MatchApi.Application.Features.Commentary.Common;
using MediatR;

namespace MatchApi.Application.Features.Commentary.Queries.GetCommentary;

public record GetCommentaryQuery(Guid FixtureId) : IRequest<IReadOnlyList<CommentaryDto>>;
