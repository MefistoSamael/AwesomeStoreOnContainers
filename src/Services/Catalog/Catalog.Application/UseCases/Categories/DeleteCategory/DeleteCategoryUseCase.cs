using MediatR;

namespace Catalog.Application.UseCases.Categories.DeleteCategory;

public class DeleteCategoryUseCase : IRequest
{
    public required string CategoryId { get; set; }
}
