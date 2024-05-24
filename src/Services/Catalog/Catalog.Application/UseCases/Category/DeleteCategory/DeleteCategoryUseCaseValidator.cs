using FluentValidation;

namespace Catalog.Application.UseCases.Category.DeleteCategory;

public class DeleteCategoryUseCaseValidator : AbstractValidator<DeleteCategoryUseCase>
{
    public DeleteCategoryUseCaseValidator()
    {
        RuleFor(deleteCategoryUseCase => deleteCategoryUseCase.CategoryId).NotEmpty();
    }
}
