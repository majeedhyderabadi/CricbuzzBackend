using MatchApi.Application.Common.Interfaces;
using MediatR;
using DomainMatch = MatchApi.Domain.Entities.Match;

namespace MatchApi.Application.Features.Matches.Commands.CreateMatch;

public class CreateMatchCommandHandler : IRequestHandler<CreateMatchCommand, CreateMatchResponse>
{
    private readonly IMatchRepository _matchRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CreateMatchCommandHandler(IMatchRepository matchRepository, IUnitOfWork unitOfWork)
    {
        _matchRepository = matchRepository;
        _unitOfWork = unitOfWork;
    }

    public async Task<CreateMatchResponse> Handle(CreateMatchCommand request, CancellationToken cancellationToken)
    {
        var match = DomainMatch.Create(request.HomeTeam, request.AwayTeam, request.MatchDateUtc, request.Venue);

        await _matchRepository.AddAsync(match, cancellationToken);
        await _unitOfWork.SaveChangesAsync(cancellationToken);

        return new CreateMatchResponse(
            match.Id,
            match.HomeTeam,
            match.AwayTeam,
            match.MatchDateUtc,
            match.Venue,
            match.Status.ToString());
    }
}
