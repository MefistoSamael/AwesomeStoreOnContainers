using FluentValidation;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInUseCaseValidator : AbstractValidator<LogInUseCase>
{
    public LogInUseCaseValidator()
    {
        RuleFor(logInUseCase => logInUseCase.Email).NotEmpty().WithMessage("Your email cannot be empty")
                     .EmailAddress().WithMessage("Your email must contain @");

        RuleFor(logInUseCase => logInUseCase.Password).NotEmpty().WithMessage("Your password cannot be empty");
    }
}
