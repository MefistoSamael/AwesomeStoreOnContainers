using FluentValidation;

namespace Identity.Application.UseCases.Authentication.Register;

public class RegisterUseCaseValidator : AbstractValidator<RegisterUseCase>
{

    public RegisterUseCaseValidator()
    {
        RuleFor(u => u.Email).NotEmpty().WithMessage("Your email cannot be empty")
                     .EmailAddress().WithMessage("Your email must contain @");

        RuleFor(u => u.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
    }
}
