using MediatR;

namespace Catalog.Application.UseCases.Categories.DeleteCategory;

public class DeleteCategoryUseCase : IRequest
{
    required public string CategoryId { get; set; }
}
