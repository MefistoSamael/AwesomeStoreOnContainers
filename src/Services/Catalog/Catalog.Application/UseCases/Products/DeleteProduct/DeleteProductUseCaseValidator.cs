using FluentValidation;

namespace Catalog.Application.UseCases.Products.DeleteProduct;

public class DeleteProductUseCaseValidator : AbstractValidator<DeleteProductUseCase>
{
    public DeleteProductUseCaseValidator()
    {
        RuleFor(deleteProductUseCase => deleteProductUseCase.ProductId).NotEmpty();
    }
}
