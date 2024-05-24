using MediatR;

namespace Catalog.Application.UseCases.Category.DeleteCategory;

public class DeleteCategoryUseCase : IRequest
{
    public required string CategoryId { get; set; }
}
