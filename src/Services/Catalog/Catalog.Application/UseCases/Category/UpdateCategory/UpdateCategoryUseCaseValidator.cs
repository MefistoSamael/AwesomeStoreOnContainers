using FluentValidation;

namespace Catalog.Application.UseCases.Category.UpdateCategory;

public class UpdateCategoryUseCaseValidator : AbstractValidator<UpdateCategoryUseCase>
{
    public UpdateCategoryUseCaseValidator()
    {
        RuleFor(updateCategoryUseCase => updateCategoryUseCase.CategoryId).NotEmpty();

        RuleFor(updateCategoryUseCase => updateCategoryUseCase.CategoryName).NotEmpty();
    }
}
