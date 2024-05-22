using FluentValidation;
using Identity.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Identity.Application.UseCases.RoleCrud.GetPaginatedRoles;

public class GetPaginatedRolesUseCaseValidator : AbstractValidator<GetPaginatedRolesUseCase>
{
    public GetPaginatedRolesUseCaseValidator(IOptions<PaginationOptions> options)
    {
        RuleFor(getPaginatedRolesUseCase => getPaginatedRolesUseCase.PageNumber).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageNumber);

        RuleFor(getPaginatedRolesUseCase => getPaginatedRolesUseCase.PageSize).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageSize);
    }
}
