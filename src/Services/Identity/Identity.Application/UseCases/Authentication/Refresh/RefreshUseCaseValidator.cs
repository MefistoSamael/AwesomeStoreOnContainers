using FluentValidation;

namespace Identity.Application.UseCases.Authentication.Refresh;

public class RefreshUseCaseValidator : AbstractValidator<RefreshUseCase>
{
    public RefreshUseCaseValidator()
    {
        RuleFor(refreshUseCase => refreshUseCase.RefreshToken).NotEmpty();

        RuleFor(refreshUseCase => refreshUseCase.AccessToken).NotEmpty();
    }
}
