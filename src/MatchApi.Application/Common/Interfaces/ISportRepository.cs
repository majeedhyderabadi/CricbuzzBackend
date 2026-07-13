
using MatchApi.Domain.Entities;

namespace MatchApi.Application.Common.Interfaces  
{
    public interface ISportRepository
    {
        Task AddSportAsync(
    Sport sport,
    CancellationToken cancellationToken);
        Task<List<Sport>> GetSortsAsync(CancellationToken cancellationToken);
    }
}
