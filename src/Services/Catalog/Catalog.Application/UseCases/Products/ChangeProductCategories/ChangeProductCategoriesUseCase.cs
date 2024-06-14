using MediatR;

namespace Catalog.Application.UseCases.Products.ChangeProductCategories;

public class ChangeProductCategoriesUseCase : IRequest<string>
{
    required public string ProductId { get; set; }

    required public IEnumerable<string> Categories { get; set; }
}
