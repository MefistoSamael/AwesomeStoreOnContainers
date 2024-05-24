using FluentValidation;

namespace Catalog.Application.UseCases.Product.UpdateProduct;

public class UpdateProductUseCaseValidator : AbstractValidator<UpdateProductUseCase>
{
    public UpdateProductUseCaseValidator()
    {
        RuleFor(updateProductUseCase => updateProductUseCase.Name).NotEmpty();

        RuleFor(updateProductUseCase => updateProductUseCase.Description).NotEmpty();

        RuleFor(updateProductUseCase => updateProductUseCase.Price).NotEmpty()
            .GreaterThan(0);
    }
}
