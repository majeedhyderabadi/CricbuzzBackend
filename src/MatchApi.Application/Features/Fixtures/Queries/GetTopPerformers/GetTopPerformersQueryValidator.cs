using FluentValidation;

namespace MatchApi.Application.Features.Fixtures.Queries.GetTopPerformers;

public class GetTopPerformersQueryValidator : AbstractValidator<GetTopPerformersQuery>
{
    public GetTopPerformersQueryValidator()
    {
        RuleFor(x => x.FixtureId)
            .NotEmpty().WithMessage("Fixture is required.");
    }
}
