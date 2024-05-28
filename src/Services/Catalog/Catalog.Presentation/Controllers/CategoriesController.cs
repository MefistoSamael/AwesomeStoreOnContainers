using Catalog.Application.UseCases.Categories.GetCategoryById;
using Catalog.Application.UseCases.Categories.GetPaginatedCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoriesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedCategoriesAsync(CancellationToken cancellationToken,
        [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
    {
        var getPaginatedCategoriesUseCase = new GetPaginatedCategoriesUseCase { PageNumber = pageNumber, PageSize = pageSize };
        var respone = await _mediator.Send(getPaginatedCategoriesUseCase, cancellationToken);

        return Ok(respone);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCategoryById(string id, CancellationToken cancellationToken)
    {
        var getCategoryByIdUseCase = new GetCategoryByIdUseCase{ CategoryId = id };
        var respone = await _mediator.Send(getCategoryByIdUseCase, cancellationToken);

        return Ok(respone);
    }
}
