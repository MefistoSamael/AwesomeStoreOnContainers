using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Categories.GetPaginatedCategory;

public class GetPaginatedCategoriesInteractor : IRequestHandler<GetPaginatedCategoriesUseCase, PaginatedResult<CategoryDTO>>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public GetPaginatedCategoriesInteractor(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    public async Task<PaginatedResult<CategoryDTO>> Handle(GetPaginatedCategoriesUseCase request, CancellationToken cancellationToken)
    {
        var domainCategories = await _categoryRepository.GetPaginatedAsync(request.PageNumber, request.PageSize, cancellationToken);

        var categories = _mapper.Map<IEnumerable<CategoryDTO>>(domainCategories);

        var count = await _categoryRepository.GetCountAsync(cancellationToken);

        var totalPages = (int)Math.Ceiling(count / (double)request.PageSize);

        return new PaginatedResult<CategoryDTO>
        {
            Collection = categories,
            CurrentPage = request.PageNumber,
            PageSize = request.PageSize,
            TotalPageCount = totalPages,
            TotalItemCount = count,
        };
    }
}
