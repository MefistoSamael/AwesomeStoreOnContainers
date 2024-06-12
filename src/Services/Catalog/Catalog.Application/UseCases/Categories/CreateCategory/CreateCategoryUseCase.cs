using MediatR;

namespace Catalog.Application.UseCases.Categories.CreateCategory;

public class CreateCategoryUseCase : IRequest<string>
{
    public required string CategoryName { get; set; }
}
