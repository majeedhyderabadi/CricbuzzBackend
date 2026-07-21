using FluentValidation;

namespace MatchApi.Application.Features.Commentary.Commands.UpdateCommentary;

public class UpdateCommentaryCommandValidator : AbstractValidator<UpdateCommentaryCommand>
{
    public UpdateCommentaryCommandValidator()
    {
        RuleFor(x => x.FixtureId)
            .NotEmpty().WithMessage("Fixture is required.");

        RuleFor(x => x.CommentaryId)
            .NotEmpty().WithMessage("Commentary entry is required.");

        RuleFor(x => x.Note)
            .MaximumLength(280).WithMessage("Note cannot exceed 280 characters.");
    }
}
