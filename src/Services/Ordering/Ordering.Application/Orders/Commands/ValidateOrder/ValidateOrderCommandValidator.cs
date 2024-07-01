using FluentValidation;

namespace Ordering.Application.Orders.Commands.ConfigureOrder;

public class ValidateOrderCommandValidator : AbstractValidator<ValidateOrderCommand>
{
    public ValidateOrderCommandValidator()
    {
        RuleFor(configureOrderCommand => configureOrderCommand.OrderId).NotEmpty();
    }
}