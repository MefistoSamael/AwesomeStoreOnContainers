using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Categories.GetPaginatedCategory;

public class GetPaginatedCategoriesUseCase : IRequest<PaginatedResult<CategoryDTO>>
{
    required public int PageNumber { get; set; }

    required public int PageSize { get; set; }
}
