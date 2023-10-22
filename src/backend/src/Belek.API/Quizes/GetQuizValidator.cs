using FluentValidation;
using FluentValidation.Validators;
using static Belek.API.Quizes.GetQuiz;

namespace Belek.API.Quizes
{
    public class CreateSalutationCommandValidator : AbstractValidator<GetQuizQuery>
    {
        public CreateSalutationCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty().NotEqual("test").WithMessage("some message");
            RuleFor(x => x).SetAsyncValidator(new GetQuizValidator());
        }
    }

    public class GetQuizValidator : IAsyncPropertyValidator<GetQuizQuery, GetQuizQuery>
    {
        public string Name => "Get quiz validator";

        public string GetDefaultMessageTemplate(string errorCode)
        {
            return "Invalid request";
        }

        public Task<bool> IsValidAsync(
            ValidationContext<GetQuizQuery> context,
            GetQuizQuery value,
            CancellationToken cancellation)
        {
            if (value.Id == "123")
            {
                context.AddFailure("some failure");
                return Task.FromResult(false);
            }

            return Task.FromResult(true);
        }
    }
}
