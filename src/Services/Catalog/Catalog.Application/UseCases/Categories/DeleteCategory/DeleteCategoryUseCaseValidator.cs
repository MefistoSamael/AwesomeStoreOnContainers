using FluentValidation;

namespace Catalog.Application.UseCases.Categories.DeleteCategory;

public class DeleteCategoryUseCaseValidator : AbstractValidator<DeleteCategoryUseCase>
{
    public DeleteCategoryUseCaseValidator()
    {
        RuleFor(deleteCategoryUseCase => deleteCategoryUseCase.CategoryId).NotEmpty();
    }
}
