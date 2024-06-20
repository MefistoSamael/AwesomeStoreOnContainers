using FluentValidation;

namespace Ordering.Application.Orders.Commands.ConfigureOrder;

public class ConfigureOrderCommandValidator : AbstractValidator<ValidateOrderCommand>
{
    public ConfigureOrderCommandValidator()
    {
        RuleFor(configureOrderCommand => configureOrderCommand.OrderId).NotEmpty();
    }
}