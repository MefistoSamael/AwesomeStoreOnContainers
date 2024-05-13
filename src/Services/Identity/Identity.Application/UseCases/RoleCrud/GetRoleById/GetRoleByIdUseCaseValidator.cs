using FluentValidation;
namespace Identity.Application.UseCases.RoleCrud.GetRoleById;

public class GetRoleByIdUseCaseValidator : AbstractValidator<GetRoleByIdUseCase>
{
    public GetRoleByIdUseCaseValidator()
    {
        RuleFor(u => u.RoleId).NotEmpty();
    }
}
