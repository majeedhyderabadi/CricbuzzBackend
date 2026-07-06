using FluentValidation;

namespace MatchApi.Application.Features.Fixtures.Commands.CreateFixture;

public class CreateFixtureCommandValidator : AbstractValidator<CreateFixtureCommand>
{
    public CreateFixtureCommandValidator()
    {
        RuleFor(x => x.HomeTeamId)
            .NotEmpty().WithMessage("Home team is required.");

        RuleFor(x => x.AwayTeamId)
            .NotEmpty().WithMessage("Away team is required.");

        RuleFor(x => x)
            .Must(x => x.HomeTeamId != x.AwayTeamId)
            .WithMessage("Home team and away team cannot be the same.");

        RuleFor(x => x.ScheduledAtUtc)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Scheduled date must be in the future.");
    }
}
