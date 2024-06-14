using FluentValidation;
using Identity.Application.Common.Options;
using Microsoft.Extensions.Options;

namespace Identity.Application.UseCases.UserCrud.GetPaginatedUsers;

public class GetPaginatedUsersUseCaseValidator : AbstractValidator<GetPaginatedUsersUseCase>
{
    public GetPaginatedUsersUseCaseValidator(IOptions<PaginationOptions> options)
    {
        RuleFor(getPaginatedUsersUseCase => getPaginatedUsersUseCase.PageNumber).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageNumber);

        RuleFor(getPaginatedUsersUseCase => getPaginatedUsersUseCase.PageSize).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.MaxPageSize);
    }
}
