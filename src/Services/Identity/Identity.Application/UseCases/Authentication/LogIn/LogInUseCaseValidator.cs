using FluentValidation;

namespace Identity.Application.UseCases.Authentication.LogIn;

public class LogInUseCaseValidator : AbstractValidator<LogInUseCase>
{
    public LogInUseCaseValidator()
    {
        RuleFor(u => u.Email).NotEmpty().WithMessage("Your email cannot be empty")
                     .EmailAddress().WithMessage("Your email must contain @");

        RuleFor(u => u.Password).NotEmpty().WithMessage("Your password cannot be empty");
    }
}
