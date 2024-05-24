using MediatR;

namespace Catalog.Application.UseCases.Category.UpdateCategory;

public class UpdateCategoryUseCase : IRequest<string>
{
    public required string CategoryId { get; set; }

    public required string CategoryName { get; set; }
}
