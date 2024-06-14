using FluentValidation;

namespace Identity.Application.UseCases.RoleCrud.GetRoleById;

public class GetRoleByIdUseCaseValidator : AbstractValidator<GetRoleByIdUseCase>
{
    public GetRoleByIdUseCaseValidator()
    {
        RuleFor(getRoleByIdUseCase => getRoleByIdUseCase.RoleId).NotEmpty();
    }
}
