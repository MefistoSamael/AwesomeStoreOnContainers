using FluentValidation;
using Identity.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Identity.Application.UseCases.RoleCrud.GetPaginatedRoles;

public class GetPaginatedRolesUseCaseValidator : AbstractValidator<GetPaginatedRolesUseCase>
{
    public GetPaginatedRolesUseCaseValidator(IOptions<PaginationOptions> options)
    {
        RuleFor(u => u.PageNumber).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageNumber);

        RuleFor(u => u.PageSize).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageSize);
    }
}
