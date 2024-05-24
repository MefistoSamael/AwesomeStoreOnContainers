using Catalog.Application.Common.Exceptions;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Category.CreateCategory;

public class CreateCategoryInteractor : IRequestHandler<CreateCategoryUseCase, string>
{
    private readonly ICategoryRepository _categoryRepository;

    public CreateCategoryInteractor(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<string> Handle(CreateCategoryUseCase request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetCategoryByNameAsync(request.CategoryName);

        if (category is not null)
        {
            throw new ExistingCategoryException("category with such name already exists");
        }

        //TODO: change to mapper
        category = new Domain.Entities.Category { Id = "", Name = request.CategoryName };

        return await _categoryRepository.CreateCategoryAsync(category);
    }
}
