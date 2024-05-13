using FluentValidation;

namespace Identity.Application.UseCases.UserCrud.GetPaginatedUsers;

public class GetPaginatedUsersUseCaseValidator : AbstractValidator<GetPaginatedUsersUseCase>
{
    public GetPaginatedUsersUseCaseValidator()
    {
        RuleFor(u => u.PageNumber).NotEmpty()
            .GreaterThan(0);

        RuleFor(u => u.PageSize).NotEmpty()
            .GreaterThan(0);
    }
}
