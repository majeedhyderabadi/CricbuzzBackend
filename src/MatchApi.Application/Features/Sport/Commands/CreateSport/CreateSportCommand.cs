using MediatR;

namespace MatchApi.Application.Features.Sport.Commands.CreateSport
{
    public class CreateSportCommand : IRequest<CreateSportResponse>
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}
