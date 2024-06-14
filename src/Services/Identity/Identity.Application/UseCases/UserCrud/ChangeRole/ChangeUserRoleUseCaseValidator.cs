using FluentValidation;

namespace Identity.Application.UseCases.UserCrud.ChangeRole;

public class ChangeUserRoleUseCaseValidator : AbstractValidator<ChangeUserRoleUseCase>
{
    public ChangeUserRoleUseCaseValidator()
    {
        RuleFor(changeUserRoleUseCase => changeUserRoleUseCase.UserId).NotEmpty();

        RuleFor(changeUserRoleUseCase => changeUserRoleUseCase.RoleName).NotEmpty();
    }
}
