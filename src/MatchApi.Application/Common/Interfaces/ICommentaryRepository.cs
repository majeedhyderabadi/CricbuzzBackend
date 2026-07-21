using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces;

public interface ICommentaryRepository
{
    Task AddAsync(CommentaryEntry entry, CancellationToken cancellationToken);

    Task<IReadOnlyList<CommentaryEntry>> GetByFixtureIdAsync(Guid fixtureId, CancellationToken cancellationToken);

    Task<CommentaryEntry?> GetByIdAsync(Guid id, CancellationToken cancellationToken);
}
