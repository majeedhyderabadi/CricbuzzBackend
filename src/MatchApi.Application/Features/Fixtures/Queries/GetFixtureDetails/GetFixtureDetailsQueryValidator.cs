using FluentValidation;

namespace MatchApi.Application.Features.Fixtures.Queries.GetFixtureDetails;

public class GetFixtureDetailsQueryValidator : AbstractValidator<GetFixtureDetailsQuery>
{
    public GetFixtureDetailsQueryValidator()
    {
        RuleFor(x => x.FixtureId)
            .NotEmpty().WithMessage("Fixture is required.");
    }
}
