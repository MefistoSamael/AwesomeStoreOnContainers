using FluentValidation;

namespace Ordering.Application.Orders.Commands.ConfirmOrderShipment;

public class ConfirmOrderShipmentCommandValidator : AbstractValidator<ConfirmOrderShipmentCommand>
{
    public ConfirmOrderShipmentCommandValidator()
    {
        RuleFor(configureOrderCommand => configureOrderCommand.OrderId).NotEmpty();
    }
}
