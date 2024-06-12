using FluentValidation;

namespace Catalog.Application.UseCases.Products.ChangeProductImage;

public class ChangeProductImageUseCaseValidator : AbstractValidator<ChangeProductImageUseCase>
{
    public ChangeProductImageUseCaseValidator()
    {
        RuleFor(changeProductImageUseCase => changeProductImageUseCase.ProductId).NotEmpty();
        RuleFor(changeProductImageUseCase => changeProductImageUseCase.Image).NotEmpty();
    }
}
