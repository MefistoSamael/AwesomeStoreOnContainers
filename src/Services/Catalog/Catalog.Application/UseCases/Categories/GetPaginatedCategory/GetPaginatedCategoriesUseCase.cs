using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Categories.GetPaginatedCategory;

public class GetPaginatedCategoriesUseCase : IRequest<PaginatedResult<CategoryDTO>>
{
    public required int PageNumber { get; set; }
    
    public required int PageSize{ get; set; }
}
