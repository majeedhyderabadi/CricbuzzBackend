using FluentValidation;

namespace MatchApi.Application.Features.Commentary.Queries.GetCommentary;

public class GetCommentaryQueryValidator : AbstractValidator<GetCommentaryQuery>
{
    public GetCommentaryQueryValidator()
    {
        RuleFor(x => x.FixtureId)
            .NotEmpty().WithMessage("Fixture is required.");
    }
}
