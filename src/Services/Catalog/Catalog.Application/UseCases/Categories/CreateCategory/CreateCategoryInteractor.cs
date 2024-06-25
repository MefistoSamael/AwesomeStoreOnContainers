using AutoMapper;
using Catalog.Application.Common.Exceptions;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryInteractor : IRequestHandler<CreateCategoryUseCase, string>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public CreateCategoryInteractor(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<string> Handle(CreateCategoryUseCase request, CancellationToken cancellationToken)
    {
        Category? category = await _categoryRepository.GetByNameAsync(request.CategoryName, cancellationToken);

        if (category is not null)
        {
            throw new ExistingCategoryException("category with such name already exists");
        }

        category = _mapper.Map<Category>(request);

        return await _categoryRepository.CreateAsync(category, cancellationToken);
    }
}
