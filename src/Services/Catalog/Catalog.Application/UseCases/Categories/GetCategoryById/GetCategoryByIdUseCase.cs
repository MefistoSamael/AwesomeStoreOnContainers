using Catalog.Application.Common.Models;
using MediatR;

namespace Catalog.Application.UseCases.Categories.GetCategoryById;

public class GetCategoryByIdUseCase : IRequest<CategoryDTO>
{
    required public string CategoryId { get; set; }
}
