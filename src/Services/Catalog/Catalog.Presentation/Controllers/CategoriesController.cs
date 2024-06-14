using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Application.UseCases.Categories.CreateCategory;
using Catalog.Application.UseCases.Categories.DeleteCategory;
using Catalog.Application.UseCases.Categories.GetCategoryById;
using Catalog.Application.UseCases.Categories.GetPaginatedCategory;
using Catalog.Application.UseCases.Categories.UpdateCategory;
using Catalog.Presentation.Requests.CategoryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Catalog.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public CategoriesController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedCategoriesAsync(
        CancellationToken cancellationToken,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 3)
    {
        GetPaginatedCategoriesUseCase getPaginatedCategoriesUseCase = new () { PageNumber = pageNumber, PageSize = pageSize };
        PaginatedResult<CategoryDTO> respone = await _mediator.Send(getPaginatedCategoriesUseCase, cancellationToken);

        return Ok(respone);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetCategoryById(string id, CancellationToken cancellationToken)
    {
        GetCategoryByIdUseCase getCategoryByIdUseCase = new () { CategoryId = id };
        CategoryDTO respone = await _mediator.Send(getCategoryByIdUseCase, cancellationToken);

        return Ok(respone);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        CreateCategoryUseCase useCase = _mapper.Map<CreateCategoryUseCase>(request);

        string result = await _mediator.Send(useCase, cancellationToken);

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] string id, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        UpdateCategoryUseCase useCase = _mapper.Map<UpdateCategoryUseCase>(request);
        useCase.CategoryId = id;

        string result = await _mediator.Send(useCase, cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        DeleteCategoryUseCase useCase = new () { CategoryId = id };

        await _mediator.Send(useCase, cancellationToken);

        return NoContent();
    }
}
