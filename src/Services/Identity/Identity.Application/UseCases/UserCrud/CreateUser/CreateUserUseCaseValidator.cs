using FluentValidation;

namespace Identity.Application.UseCases.UserCrud.CreateUser;

public class CreateUserUseCaseValidator : AbstractValidator<CreateUserUseCase>
{
    public CreateUserUseCaseValidator()
    {
        RuleFor(u => u.Email).NotEmpty().WithMessage("Email cannot be empty")
                     .EmailAddress().WithMessage("Email must contain @");

        RuleFor(u => u.Password).NotEmpty().WithMessage("Password cannot be empty")
                    .MinimumLength(8).WithMessage("Password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Password must contain at least one number.");

        RuleFor(u => u.Role).NotEmpty();
    }
}
