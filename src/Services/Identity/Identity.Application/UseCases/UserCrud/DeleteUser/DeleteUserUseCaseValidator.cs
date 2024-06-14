using FluentValidation;

namespace Identity.Application.UseCases.UserCrud.DeleteUser;

public class DeleteUserUseCaseValidator : AbstractValidator<DeleteUserUseCase>
{
    public DeleteUserUseCaseValidator()
    {
        RuleFor(deleteUserUseCase => deleteUserUseCase.Id).NotEmpty();
    }
}
