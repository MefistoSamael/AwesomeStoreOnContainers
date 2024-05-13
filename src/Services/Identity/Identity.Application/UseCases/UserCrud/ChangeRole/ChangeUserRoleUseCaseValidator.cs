using FluentValidation;

namespace Identity.Application.UseCases.UserCrud.ChangeRole;

public class ChangeUserRoleUseCaseValidator : AbstractValidator<ChangeUserRoleUseCase>
{
    public ChangeUserRoleUseCaseValidator()
    {
        RuleFor(u => u.UserId).NotEmpty();

        RuleFor(u => u.RoleName).NotEmpty();
    }
}
