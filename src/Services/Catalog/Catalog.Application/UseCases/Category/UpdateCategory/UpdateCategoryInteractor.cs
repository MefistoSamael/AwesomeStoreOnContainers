using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Category.UpdateCategory;

public class UpdateCategoryInteractor : IRequestHandler<UpdateCategoryUseCase, string>
{
    private readonly ICategoryRepository _categoryRepository;

    public UpdateCategoryInteractor(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<string> Handle(UpdateCategoryUseCase request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId);

        if (category is null)
        {
            throw new KeyNotFoundException("can't find category with such id");
        }

        category.Name = request.CategoryName;

        await _categoryRepository.UpdateCategoryAsync(category);

        return category.Id;
    }
}
