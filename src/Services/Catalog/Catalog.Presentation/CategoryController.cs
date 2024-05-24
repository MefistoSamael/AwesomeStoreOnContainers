using Catalog.Application.UseCases.Category.GetPaginatedCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Presentation;

[Route("api/[controller]")]
[ApiController]
public class CategoryController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedCategoriesAsync([FromQuery] int pageNumber, [FromQuery] int pageSize)
    {
        var getPaginatedCategoriesUseCase = new GetPaginatedCategoriesUseCase { PageNumber = pageNumber, PageSize = pageSize };
        var respone = await _mediator.Send(getPaginatedCategoriesUseCase);

        return Ok(respone);
    }
}
