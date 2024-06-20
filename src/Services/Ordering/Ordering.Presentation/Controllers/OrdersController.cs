using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Ordering.Application.Orders.Commands.CancelOrder;
using Ordering.Application.Orders.Commands.ConfigureOrder;
using Ordering.Application.Orders.Commands.ConfirmOrderShipment;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Application.Orders.Queries.GetUsersActiveOrder;
using Ordering.Application.Orders.Queries.GetUsersOrders;

namespace Ordering.Presentation.Controllers;

[Route("[controller]/")]
[ApiController]
public class OrdersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public OrdersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    public async Task<IActionResult> CreateOrderAsync([FromBody] CreateOrderCommand command, CancellationToken cancellationToken = default)
    {
        var result = await _mediator.Send(command, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [Route("users/{userId}")]
    public async Task<IActionResult> GetUsersOrdersAsync(
        [FromRoute] string userId,
        [FromQuery] int pageNumber = 1,
        [FromQuery] int pageSize = 3,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUsersOrderQuery { PageNumber = pageNumber, PageSize = pageSize, UserId = userId };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpGet]
    [Route("users/{userId}/active")]
    public async Task<IActionResult> GetUsersActiveOrderAsync(
        [FromRoute] string userId,
        CancellationToken cancellationToken = default)
    {
        var query = new GetUsersActiveOrderQuery { UserId = userId };

        var result = await _mediator.Send(query, cancellationToken);

        return Ok(result);
    }

    [HttpPost]
    [Route("{orderId}/cancel")]
    public async Task<IActionResult> ChangeOrderStateAsync(
    [FromRoute] string orderId,
    CancellationToken cancellationToken = default)
    {
        var command = new CancelOrderCommand { OrderId = orderId };

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPost]
    [Route("{orderId}/configure")]
    public async Task<IActionResult> ConfigureOrderAsync(
    [FromRoute] string orderId,
    CancellationToken cancellationToken = default)
    {
        var command = new ConfigureOrderCommand { OrderId = orderId };

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPost]
    [Route("{orderId}/validate")]
    public async Task<IActionResult> ValidateOrderAsync(
    [FromRoute] string orderId,
    CancellationToken cancellationToken = default)
    {
        var command = new ValidateOrderCommand { OrderId = orderId };

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }

    [HttpPost]
    [Route("{orderId}/confirm-shipment")]
    public async Task<IActionResult> ConfirmOrderShipmentAsync(
    [FromRoute] string orderId,
    CancellationToken cancellationToken = default)
    {
        var command = new ConfirmOrderShipmentCommand { OrderId = orderId };

        await _mediator.Send(command, cancellationToken);

        return NoContent();
    }
}
