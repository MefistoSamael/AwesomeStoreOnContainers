using MediatR;

namespace Ordering.Application.Orders.Commands.ConfirmOrderShipment;

public class ConfirmOrderShipmentCommand : IRequest
{
    required public string OrderId { get; set; }
}
