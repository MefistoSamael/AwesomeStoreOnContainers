using FluentValidation;

namespace Ordering.Application.Orders.Queries.GetUsersOrders;

public class GetUsersOrderQueryValidator : AbstractValidator<GetUsersOrderQuery>
{
    public GetUsersOrderQueryValidator()
    {
        RuleFor(getUsersOrderQuery => getUsersOrderQuery.UserId).NotEmpty();

        RuleFor(getUsersOrderQuery => getUsersOrderQuery.PageNumber).GreaterThan(0).LessThan(99);

        RuleFor(getUsersOrderQuery => getUsersOrderQuery.PageSize).GreaterThan(0).LessThan(99);
    }
}
