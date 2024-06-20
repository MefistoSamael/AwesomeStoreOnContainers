using FluentValidation;

namespace Ordering.Application.Orders.Queries.GetUsersActiveOrder;

public class GetUsersActiveOrderQueryValidator : AbstractValidator<GetUsersActiveOrderQuery>
{
    public GetUsersActiveOrderQueryValidator()
    {
        RuleFor(getUsersActiveOrderQuery => getUsersActiveOrderQuery.UserId).NotEmpty();
    }
}
