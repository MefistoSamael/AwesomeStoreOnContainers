using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Categories.DeleteCategory;

public class DeleteCategoryInteractor : IRequestHandler<DeleteCategoryUseCase>
{
    private readonly ICategoryRepository _categoryRepository;
public DeleteCategoryInteractor(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task Handle(DeleteCategoryUseCase request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            return;
        }
        
        await _categoryRepository.DeleteCategoryAsync(category, cancellationToken);
    }
}
