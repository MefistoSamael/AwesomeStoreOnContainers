using FluentValidation;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(createOrderCommand => createOrderCommand.BuyerId).NotEmpty();

        RuleFor(createOrderCommand => createOrderCommand.Description).NotEmpty();

        RuleFor(createOrderCommand => createOrderCommand.Description.Length).NotEmpty().LessThanOrEqualTo(150);
    }
}
