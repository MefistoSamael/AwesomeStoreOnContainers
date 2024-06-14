using MediatR;

namespace Catalog.Application.UseCases.Categories.UpdateCategory;

public class UpdateCategoryUseCase : IRequest<string>
{
    required public string CategoryId { get; set; }

    required public string CategoryName { get; set; }
}
