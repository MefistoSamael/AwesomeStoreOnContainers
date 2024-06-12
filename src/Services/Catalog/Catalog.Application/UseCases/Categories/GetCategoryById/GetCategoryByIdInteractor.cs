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
        var category = await _categoryRepository.GetCategoryByIdAsync(request.CategoryId, cancellationToken);

        if (category is null)
        {
            throw new KeyNotFoundException("category with such id wasn't found");
        }

        return _mapper.Map<CategoryDTO>(category);
    }
}
