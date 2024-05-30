using FluentValidation;

namespace Catalog.Application.UseCases.Products.GetProductById;

public class GetProductByIdUseCaseValidator : AbstractValidator<GetProductByIdUseCase>
{
    public GetProductByIdUseCaseValidator()
    {
        RuleFor(getProductByIdUseCase => getProductByIdUseCase.ProductId).NotEmpty();
    }
}
