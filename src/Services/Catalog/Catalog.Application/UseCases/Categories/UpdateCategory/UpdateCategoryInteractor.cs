using AutoMapper;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Categories.UpdateCategory;

public class UpdateCategoryInteractor : IRequestHandler<UpdateCategoryUseCase, string>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public UpdateCategoryInteractor(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateCategoryUseCase request, CancellationToken cancellationToken)
    {
        Domain.Entities.Category? category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            throw new KeyNotFoundException("can't find category with such id");
        }

        category = _mapper.Map(request, category);

        await _categoryRepository.UpdateAsync(category, cancellationToken);

        return category.Id;
    }
}
