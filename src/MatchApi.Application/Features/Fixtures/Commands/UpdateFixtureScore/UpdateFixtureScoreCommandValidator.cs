using FluentValidation;

namespace MatchApi.Application.Features.Fixtures.Commands.UpdateFixtureScore;

public class UpdateFixtureScoreCommandValidator : AbstractValidator<UpdateFixtureScoreCommand>
{
    public UpdateFixtureScoreCommandValidator()
    {
        RuleFor(x => x.FixtureId)
            .NotEmpty().WithMessage("Fixture is required.");

        RuleFor(x => x.Side)
            .IsInEnum().WithMessage("Side must be either Home or Away.");

        RuleFor(x => x)
            .Must(x => x.RunsDelta != 0 || (x.WicketsDelta ?? 0) != 0)
            .WithMessage("At least one of RunsDelta or WicketsDelta must be non-zero.");
    }
}
