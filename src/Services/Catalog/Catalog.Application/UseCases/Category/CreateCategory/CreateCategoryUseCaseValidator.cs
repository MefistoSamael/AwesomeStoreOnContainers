using FluentValidation;

namespace Catalog.Application.UseCases.Category.CreateCategory;

public class CreateCategoryUseCaseValidator : AbstractValidator<CreateCategoryUseCase>
{
    public CreateCategoryUseCaseValidator()
    {
        RuleFor(createCategoryUseCase => createCategoryUseCase.CategoryName).NotEmpty();
    }
}
