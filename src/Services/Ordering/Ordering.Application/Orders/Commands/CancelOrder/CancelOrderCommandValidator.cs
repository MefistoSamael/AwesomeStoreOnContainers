using FluentValidation;
using MediatR;

namespace Ordering.Application.Orders.Commands.CancelOrder;

public class CancelOrderCommandValidator : AbstractValidator<CancelOrderCommand>
{
    public CancelOrderCommandValidator()
    {
        RuleFor(configureOrderCommand => configureOrderCommand.OrderId).NotEmpty();
    }
}
