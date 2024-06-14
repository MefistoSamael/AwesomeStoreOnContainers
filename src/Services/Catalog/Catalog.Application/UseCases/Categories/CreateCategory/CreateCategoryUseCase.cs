using MediatR;

namespace Catalog.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryUseCase : IRequest<string>
{
    required public string CategoryName { get; set; }
}
