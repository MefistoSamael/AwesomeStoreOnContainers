using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Categories.GetCategoryById;

public class GetCategoryByIdInteractor : IRequestHandler<GetCategoryByIdUseCase, CategoryDTO>
{
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public GetCategoryByIdInteractor(ICategoryRepository categoryRepository, IMapper mediator)
    {
        _categoryRepository = categoryRepository;
        _mapper = mediator;
    }

    public async Task<CategoryDTO> Handle(GetCategoryByIdUseCase request, CancellationToken cancellationToken)
    {
        Domain.Entities.Category? category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId, cancellationToken);

        return category is null ? throw new KeyNotFoundException("category with such id wasn't found") : _mapper.Map<CategoryDTO>(category);
    }
}
