using FluentValidation;

namespace Ordering.Application.OrderItems.Commands.RemoveOrderItemFromOrderCommand;

public class RemoveOrderItemFromOrderCommandValidator : AbstractValidator<RemoveOrderItemFromOrderCommand>
{
    public RemoveOrderItemFromOrderCommandValidator()
    {
        RuleFor(removeOrderItemFromOrderCommand => removeOrderItemFromOrderCommand.OrderItemId).NotEmpty();
    }
}