using FluentValidation;

namespace Catalog.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryUseCaseValidator : AbstractValidator<CreateCategoryUseCase>
{
    public CreateCategoryUseCaseValidator()
    {
        RuleFor(createCategoryUseCase => createCategoryUseCase.CategoryName).NotEmpty();
    }
}
