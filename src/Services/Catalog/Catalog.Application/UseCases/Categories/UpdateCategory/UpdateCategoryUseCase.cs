using MediatR;

namespace Catalog.Application.UseCases.Categories.UpdateCategory;

public class UpdateCategoryUseCase : IRequest<string>
{
    public required string CategoryId { get; set; }

    public required string CategoryName { get; set; }
}
