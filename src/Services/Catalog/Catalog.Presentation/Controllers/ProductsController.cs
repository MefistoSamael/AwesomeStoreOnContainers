using AutoMapper;
using Catalog.Application.UseCases.Products.CreateProducts;
using Catalog.Application.UseCases.Products.DeleteProduct;
using Catalog.Application.UseCases.Products.GetPaginatedProducts;
using Catalog.Application.UseCases.Products.GetProductById;
using Catalog.Application.UseCases.Products.UpdateProduct;
using Catalog.Application.UseCases.Products.ChangeProductImage;
using Catalog.Presentation.Requests.ProductRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Catalog.Application.UseCases.Products.ChangeProductCategories;

namespace Catalog.Presentation.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ProductsController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public ProductsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpGet]
    public async Task<IActionResult> GetPaginatedProductsAsync(CancellationToken cancellationToken, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
    {
        var useCase = new GetPaginatedProductsUseCase { PageNumber = pageNumber, PageSize = pageSize };

        var response = await _mediator.Send(useCase, cancellationToken);

        return Ok(response);
    }

    [HttpGet]
    [Route("{id}")]
    public async Task<IActionResult> GetProductByIdAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        var useCase = new GetProductByIdUseCase { ProductId = id };

        var response = await _mediator.Send(useCase, cancellationToken);

        return Ok(response);
    }

    [HttpPatch]
    [Route("{id}")]
    public async Task<IActionResult> PatchProductAsync([FromRoute] string id, [FromBody] UpdateProductRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<UpdateProductUseCase>(request);
        useCase.ProductId = id;

        var response = await _mediator.Send(useCase, cancellationToken);

        return Ok(response);
    }

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<CreateProductUseCase>(request);

        var response = await _mediator.Send(useCase, cancellationToken);

        return Ok(response);
    }

    [HttpDelete]
    [Route("{id}")]
    public async Task<IActionResult> DeleteProductAsync([FromRoute] string id, CancellationToken cancellationToken)
    {
        var useCase = new DeleteProductUseCase { ProductId = id };

        await _mediator.Send(useCase, cancellationToken);

        return Ok();
    }

    [HttpPatch]
    [Route("{id}/image")]
    public async Task<IActionResult> ChangeImageAsync([FromRoute] string id, [FromForm] ChangeProductImageRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<ChangeProductImageUseCase>(request);
        useCase.ProductId = id;

        var result = await _mediator.Send(useCase, cancellationToken);

        return Ok(result);
    }

    [HttpPatch]
    [Route("{id}/categories")]
    public async Task<IActionResult> ChangeCategoriesAsync([FromRoute] string id, [FromBody] ChangeProductCategoriesRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<ChangeProductCategoriesUseCase>(request);
        useCase.ProductId = id;

        var result = await _mediator.Send(useCase, cancellationToken);

        return Ok(result);
    }
}
