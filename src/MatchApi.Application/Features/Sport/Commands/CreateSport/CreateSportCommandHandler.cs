using MatchApi.Application.Common.Interfaces;
using MediatR;

namespace MatchApi.Application.Features.Sport.Commands.CreateSport
{
    public class CreateSportCommandHandler
    : IRequestHandler<CreateSportCommand, CreateSportResponse>
    {
        private readonly ISportRepository _repository;

        public CreateSportCommandHandler(ISportRepository repository)
        {
            _repository = repository;
        }

        public async Task<CreateSportResponse> Handle(
            CreateSportCommand request,
            CancellationToken cancellationToken)
        {
            var sport = new Domain.Entities.Sport
            {
                Name = request.Name,
                Description = request.Description
            };

            await _repository.AddSportAsync(sport, cancellationToken);

            return new CreateSportResponse
            {
                Id = sport.Id,
                Name = sport.Name
            };
        }
    }
}
