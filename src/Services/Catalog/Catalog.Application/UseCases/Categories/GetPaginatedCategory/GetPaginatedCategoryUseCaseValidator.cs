using Catalog.Application.Common.Options;
using FluentValidation;
using Microsoft.Extensions.Options;

namespace Catalog.Application.UseCases.Categories.GetPaginatedCategory;

public class GetPaginatedCategoryUseCaseValidator : AbstractValidator<GetPaginatedCategoriesUseCase>
{
    public GetPaginatedCategoryUseCaseValidator(IOptions<CategoryPaginationOptions> options)
    {
        RuleFor(getPaginatedCategoriesUseCase => getPaginatedCategoriesUseCase.PageNumber)
            .LessThanOrEqualTo(options.Value.PageNumber)
            .GreaterThan(0);

        RuleFor(getPaginatedCategoriesUseCase => getPaginatedCategoriesUseCase.PageSize)
            .LessThanOrEqualTo(options.Value.PageSize)
            .GreaterThan(0);
    }
}
