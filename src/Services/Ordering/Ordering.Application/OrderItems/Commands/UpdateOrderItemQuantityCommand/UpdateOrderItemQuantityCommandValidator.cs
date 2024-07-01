using FluentValidation;

namespace Ordering.Application.OrderItems.Commands.UpdateOrderItemQuantityCommand;

public class UpdateOrderItemQuantityCommandValidator : AbstractValidator<UpdateOrderItemQuantityCommand>
{
    public UpdateOrderItemQuantityCommandValidator()
    {
        RuleFor(updateOrderItemQuantityCommand => updateOrderItemQuantityCommand.OrderItemId).NotEmpty();
        RuleFor(updateOrderItemQuantityCommand => updateOrderItemQuantityCommand.NewQuantity)
            .GreaterThan(0).WithMessage("Quantity must be greater than zero");
    }
}