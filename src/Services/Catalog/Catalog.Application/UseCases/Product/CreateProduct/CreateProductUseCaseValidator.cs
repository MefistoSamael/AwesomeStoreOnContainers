using FluentValidation;

namespace Catalog.Application.UseCases.Product.CreateProduct;

public class CreateProductUseCaseValidator : AbstractValidator<CreateProductUseCase>
{
    public CreateProductUseCaseValidator()
    {
        RuleFor(createProductUseCase => createProductUseCase.Name).NotEmpty();

        RuleFor(createProductUseCase => createProductUseCase.Description).NotEmpty();

        RuleFor(createProductUseCase => createProductUseCase.Price).NotEmpty()
            .GreaterThan(0);
        
        RuleFor(createProductUseCase => createProductUseCase.Image).NotEmpty();

        RuleFor(createProductUseCase => createProductUseCase.StockCount).GreaterThanOrEqualTo(0);

        RuleFor(createProductUseCase => createProductUseCase.Categories).NotEmpty();
    }
}
