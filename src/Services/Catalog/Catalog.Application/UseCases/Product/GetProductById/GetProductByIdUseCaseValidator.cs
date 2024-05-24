using FluentValidation;

namespace Catalog.Application.UseCases.Product.GetProductById;

public class GetProductByIdUseCaseValidator : AbstractValidator<GetProductByIdUseCase>
{
    public GetProductByIdUseCaseValidator()
    {
        RuleFor(getProductByIdUseCase => getProductByIdUseCase.ProductId).NotEmpty();
    }
}
