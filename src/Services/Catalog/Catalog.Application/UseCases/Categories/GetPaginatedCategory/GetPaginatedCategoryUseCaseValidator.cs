using FluentValidation;

namespace Catalog.Application.UseCases.Categories.GetPaginatedCategory;

public class GetPaginatedCategoryUseCaseValidator : AbstractValidator<GetPaginatedCategoriesUseCase>
{
    private const int MaxPageNumber = 20;
    private const int MaxPageSize = 20;

    public GetPaginatedCategoryUseCaseValidator()
    {
        RuleFor(getPaginatedCategoriesUseCase => getPaginatedCategoriesUseCase.PageNumber)
            .LessThanOrEqualTo(MaxPageNumber)
            .GreaterThan(0);

        RuleFor(getPaginatedCategoriesUseCase => getPaginatedCategoriesUseCase.PageSize)
            .LessThanOrEqualTo(MaxPageSize)
            .GreaterThan(0);
    }
}
