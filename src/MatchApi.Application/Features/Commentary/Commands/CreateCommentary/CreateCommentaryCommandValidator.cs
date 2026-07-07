using FluentValidation;

namespace MatchApi.Application.Features.Commentary.Commands.CreateCommentary;

public class CreateCommentaryCommandValidator : AbstractValidator<CreateCommentaryCommand>
{
    public CreateCommentaryCommandValidator()
    {
        RuleFor(x => x.FixtureId)
            .NotEmpty().WithMessage("Fixture is required.");

        RuleFor(x => x.PlayerId)
            .NotEmpty().WithMessage("Player is required.");

        RuleFor(x => x.Side)
            .IsInEnum().WithMessage("Side must be either Home or Away.");

        RuleFor(x => x.Action)
            .IsInEnum().WithMessage("Action is not a recognized commentary action.");

        RuleFor(x => x.Note)
            .MaximumLength(280).WithMessage("Note cannot exceed 280 characters.");
    }
}
