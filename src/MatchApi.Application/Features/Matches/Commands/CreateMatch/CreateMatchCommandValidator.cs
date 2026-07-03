using FluentValidation;

namespace MatchApi.Application.Features.Matches.Commands.CreateMatch;

public class CreateMatchCommandValidator : AbstractValidator<CreateMatchCommand>
{
    public CreateMatchCommandValidator()
    {
        RuleFor(x => x.HomeTeam)
            .NotEmpty().WithMessage("Home team is required.")
            .MaximumLength(100);

        RuleFor(x => x.AwayTeam)
            .NotEmpty().WithMessage("Away team is required.")
            .MaximumLength(100);

        RuleFor(x => x)
            .Must(x => !string.Equals(x.HomeTeam, x.AwayTeam, StringComparison.OrdinalIgnoreCase))
            .WithMessage("Home team and away team cannot be the same.");

        RuleFor(x => x.MatchDateUtc)
            .GreaterThan(DateTime.UtcNow)
            .WithMessage("Match date must be in the future.");

        RuleFor(x => x.Venue)
            .NotEmpty().WithMessage("Venue is required.")
            .MaximumLength(200);
    }
}
