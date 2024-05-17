using MediatR;

namespace Catalog.Application.UseCases.Category.CreateCategory;

public class CreateCategoryUseCase : IRequest<string>
{
    public required string CategoryName { get; set; }
}
