using MediatR;

namespace Catalog.Application.UseCases.Products.ChangeProductCategories;

public class ChangeProductCategoriesUseCase : IRequest<string>
{
    public required string ProductId { get; set; }

    public required IEnumerable<string> Categories { get; set; }
}
