using FluentValidation;
using Ordering.Application.Orders.Commands.ConfigureOrder;

namespace Ordering.Application.Orders.Commands.ConfirmOrderShipment;

public class ConfirmOrderShipmentCommandValidator : AbstractValidator<ConfirmOrderShipmentCommand>
{
    public ConfirmOrderShipmentCommandValidator()
    {
        RuleFor(configureOrderCommand => configureOrderCommand.OrderId).NotEmpty();
    }
}
