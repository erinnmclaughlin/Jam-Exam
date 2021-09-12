using FluentValidation;
using Shared.Models;

namespace Shared.Validators
{
    public class CreateGameValidator : AbstractValidator<CreateGameModel>
    {
        public CreateGameValidator()
        {
            RuleFor(x => x.Difficulty)
                .NotNull().WithMessage("You must select a difficulty.")
                .GreaterThanOrEqualTo(0).LessThan(4);

            RuleFor(x => x.NumberOfQuestions)
                .GreaterThanOrEqualTo(5).WithMessage("You cannot create a game with fewer than 5 questions.")
                .LessThanOrEqualTo(50).WithMessage("You cannot create a game with more than 50 questions.");
        }
    }
}
