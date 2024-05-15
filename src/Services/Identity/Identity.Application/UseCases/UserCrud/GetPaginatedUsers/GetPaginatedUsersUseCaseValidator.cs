using FluentValidation;
using Identity.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Identity.Application.UseCases.UserCrud.GetPaginatedUsers;

public class GetPaginatedUsersUseCaseValidator : AbstractValidator<GetPaginatedUsersUseCase>
{
    public GetPaginatedUsersUseCaseValidator(IOptions<PaginationOptions> options)
    {
        RuleFor(u => u.PageNumber).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageNumber);

        RuleFor(u => u.PageSize).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageSize);
    }
}
