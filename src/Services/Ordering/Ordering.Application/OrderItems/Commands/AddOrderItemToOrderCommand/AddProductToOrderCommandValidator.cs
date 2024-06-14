using FluentValidation;

namespace Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;

public class AddProductToOrderCommandValidator : AbstractValidator<AddProductToOrderCommand>
{
    public AddProductToOrderCommandValidator()
    {
        RuleFor(addProductToOrderCommand => addProductToOrderCommand.ProductId).NotEmpty();
        RuleFor(addProductToOrderCommand => addProductToOrderCommand.OrderId).NotEmpty();
        RuleFor(addProductToOrderCommand => addProductToOrderCommand.Quantity).NotEmpty()
            .GreaterThan(0);
    }
}
