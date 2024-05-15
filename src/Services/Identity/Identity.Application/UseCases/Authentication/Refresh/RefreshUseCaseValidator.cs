using FluentValidation;

namespace Identity.Application.UseCases.Authentication.Refresh;

public class RefreshUseCaseValidator : AbstractValidator<RefreshUseCase>
{
    public RefreshUseCaseValidator()
    {
        RuleFor(x => x.RefreshToken).NotEmpty();

        RuleFor(x => x.AccessToken).NotEmpty();
    }
}
