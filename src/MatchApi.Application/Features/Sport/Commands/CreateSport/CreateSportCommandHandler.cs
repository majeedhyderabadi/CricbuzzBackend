using MatchApi.Application.Common.Interfaces;
using MatchApi.Domain.DTOs;
using MediatR;
using System.Net;

namespace MatchApi.Application.Features.Sport.Commands.CreateSport
{
    public class CreateSportCommandHandler
    : IRequestHandler<CreateSportCommand, ResponseResult<string>>
    {
        private readonly ISportRepository _repository;

        public CreateSportCommandHandler(ISportRepository repository)
        {
            _repository = repository;
        }

        public async Task<ResponseResult<string>> Handle(
            CreateSportCommand request,
            CancellationToken cancellationToken)
        {
            if (await _repository.isSportExist(request.Name, cancellationToken))
            {
                return new ResponseResult<string> { Success = false, Message = "Sport with the same name already exists." };
            }
            var newSport = new Domain.Entities.Sport
            {
                Name = request.Name,
                Description = request.Description
            };
            await _repository.AddSportAsync(newSport, cancellationToken);
            return new ResponseResult<string>
            {
                Success = true,
                Message = "Sport created successfully.",
            };
        }
    }
}
