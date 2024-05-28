using FluentValidation;

namespace Catalog.Application.UseCases.Product.DeleteProduct;

public class DeleteProductUseCaseValidator : AbstractValidator<DeleteProductUseCase>
{
    public DeleteProductUseCaseValidator()
    {
        RuleFor(deleteProductUseCase => deleteProductUseCase.ProductId).NotEmpty();
    }
}
