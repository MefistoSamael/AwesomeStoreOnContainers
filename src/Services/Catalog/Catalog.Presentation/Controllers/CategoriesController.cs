using AutoMapper;
using Catalog.Application.UseCases.Categories.CreateCategory;
using Catalog.Application.UseCases.Categories.DeleteCategory;
using Catalog.Application.UseCases.Categories.GetCategoryById;
using Catalog.Application.UseCases.Categories.GetPaginatedCategory;
using Catalog.Application.UseCases.Categories.UpdateCategory;
using Catalog.Presentation.Requests.CategoryRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using ZstdSharp.Unsafe;

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
        var getCategoryByIdUseCase = new GetCategoryByIdUseCase { CategoryId = id };
        var respone = await _mediator.Send(getCategoryByIdUseCase, cancellationToken);

        return Ok(respone);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategoryAsync([FromBody] CreateCategoryRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<CreateCategoryUseCase>(request);

        var result = await _mediator.Send(useCase, cancellationToken);

        return Ok(result);
    }

    [HttpPut]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] string id, [FromBody] UpdateCategoryRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<UpdateCategoryUseCase>(request);
        useCase.CategoryId = id;

        var result = await _mediator.Send(useCase, cancellationToken);

        return Ok(result);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> UpdateCategoryAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        var useCase = new DeleteCategoryUseCase { CategoryId = id };

        await _mediator.Send(useCase, cancellationToken);

        return Ok();
    }
}
