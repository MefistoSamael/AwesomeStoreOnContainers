using FluentValidation;

namespace Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;

public class GetOrderItemsFromOrderQueryValidator : AbstractValidator<GetOrderItemsFromOrderQuery>
{
    public GetOrderItemsFromOrderQueryValidator()
    {
        RuleFor(getOrderItemsFromOrderQuery => getOrderItemsFromOrderQuery.OrderId).NotEmpty();
    }
}
