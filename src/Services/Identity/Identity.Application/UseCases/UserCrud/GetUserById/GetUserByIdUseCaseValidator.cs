using FluentValidation;

namespace Identity.Application.UseCases.UserCrud.GetUserById;

public class GetUserByIdUseCaseValidator : AbstractValidator<GetUserByIdUseCase>
{
    public GetUserByIdUseCaseValidator()
    {
        RuleFor(getUserByIdUseCase => getUserByIdUseCase.UserId).NotEmpty();
    }
}
