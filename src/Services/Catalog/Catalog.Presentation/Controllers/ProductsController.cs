using AutoMapper;
using Catalog.Application.UseCases.Product.CreateProduct;
using Catalog.Presentation.Requests.ProductRequests;
using MediatR;
using Microsoft.AspNetCore.Mvc;

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

    [HttpPost]
    public async Task<IActionResult> CreateProductAsync([FromForm] CreateProductRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<CreateProductUseCase>(request);

        var response = await _mediator.Send(useCase, cancellationToken);

        return Ok(response);
    }
}
