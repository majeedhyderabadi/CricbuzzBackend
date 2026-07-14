using MatchApi.Domain.DTOs.Cricket;
using MediatR;

public class GetCricbuzzMatchesQueryHandler
    : IRequestHandler<GetCricbuzzMatchesQuery, CricbuzzMatchListDto?>
{
    private readonly ICricbuzzService _cricbuzzService;

    public GetCricbuzzMatchesQueryHandler(ICricbuzzService cricbuzzService)
    {
        _cricbuzzService = cricbuzzService;
    }

    public async Task<CricbuzzMatchListDto?> Handle(
        GetCricbuzzMatchesQuery request,
        CancellationToken cancellationToken)
    {
        return await _cricbuzzService.GetMatchesAsync();
    }
}