using FluentValidation;

namespace Catalog.Application.UseCases.Product.GetPaginatedProducts;

public class GetPaginatedProductsUseCaseValidator : AbstractValidator<GetPaginatedProductsUseCase>
{
    //TODO: use options to initialize this values
    private const int MaxPageNumber = 100;
    private const int MaxPageSize= 20;

    public GetPaginatedProductsUseCaseValidator()
    {
        RuleFor(getPaginatedProductsUseCase => getPaginatedProductsUseCase.PageNumber).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(MaxPageNumber);

        RuleFor(getPaginatedProductsUseCase => getPaginatedProductsUseCase.PageSize).NotEmpty()
            .GreaterThan(0)
            .LessThanOrEqualTo(MaxPageSize);
    }
}
