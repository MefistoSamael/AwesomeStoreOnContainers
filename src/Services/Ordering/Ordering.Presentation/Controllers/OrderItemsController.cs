using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;
using Ordering.Application.OrderItems.Commands.RemoveOrderItemFromOrderCommand;
using Ordering.Application.OrderItems.Commands.UpdateOrderItemQuantityCommand;
using Ordering.Presentation.Common.Requests;

namespace Ordering.Presentation.Controllers;

[Route("[controller]/")]
[ApiController]
public class OrderItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    private readonly IMapper _mapper;

    public OrderItemsController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> AddProductToOrderAsync(
        [FromBody] AddProductToOrderRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<AddProductToOrderCommand>(request);

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpDelete]
    [Route("{orderItemId}")]
    public async Task<IActionResult> RemoveOrderItemFromOrder(
        [FromRoute] string orderItemId,
        CancellationToken cancellationToken)
    {
        var command = new RemoveOrderItemFromOrderCommand { OrderItemId = orderItemId };

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPatch]
    [Route("{orderItemId}")]
    public async Task<IActionResult> UpdateOrderItemQuantity(
        [FromRoute] string orderItemId,
        [FromBody] UpdateOrderItemQuantityRequest request,
        CancellationToken cancellationToken)
    {
        var command = _mapper.Map<UpdateOrderItemQuantityCommand>(request);
        command.OrderItemId = orderItemId;

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }
}
