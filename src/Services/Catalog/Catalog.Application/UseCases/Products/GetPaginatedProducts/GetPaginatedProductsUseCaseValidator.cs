using Catalog.Application.Common.Options;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Catalog.Application.UseCases.Products.GetPaginatedProducts;

public class GetPaginatedProductsUseCaseValidator : AbstractValidator<GetPaginatedProductsUseCase>
{
    public GetPaginatedProductsUseCaseValidator(IOptions<ProductPaginationOptions> options)
    {
        RuleFor(getPaginatedProductsUseCase => getPaginatedProductsUseCase.PageNumber).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.PageNumber);

        RuleFor(getPaginatedProductsUseCase => getPaginatedProductsUseCase.PageSize).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(options.Value.PageSize);
    }
}
