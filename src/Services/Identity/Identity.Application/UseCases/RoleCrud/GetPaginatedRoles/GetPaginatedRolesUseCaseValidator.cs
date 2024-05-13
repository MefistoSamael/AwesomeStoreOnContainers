using FluentValidation;

namespace Identity.Application.UseCases.RoleCrud.GetPaginatedRoles;

public class GetPaginatedRolesUseCaseValidator : AbstractValidator<GetPaginatedRolesUseCase>
{
    public GetPaginatedRolesUseCaseValidator()
    {
        RuleFor(u => u.PageNumber).NotEmpty()
            .GreaterThan(0);

        RuleFor(u => u.PageSize).NotEmpty()
            .GreaterThan(0);
    }
}
