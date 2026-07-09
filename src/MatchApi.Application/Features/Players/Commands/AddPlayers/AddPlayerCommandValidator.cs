using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MatchApi.Application.Features.Players.Commands.AddPlayers
{
    public class AddPlayerCommandValidator : AbstractValidator<AddPlayerCommand>
    {
        public AddPlayerCommandValidator()
        {
            RuleFor(x => x.TeamId)
                .NotEmpty();

            RuleFor(x => x.PlayerName)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(x => x.Role)
                .NotEmpty()
                .MaximumLength(50);
        }
    }
}
