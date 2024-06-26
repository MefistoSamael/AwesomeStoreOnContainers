using Ordering.Domain.Entities;
using Ordering.Infrastructure.Specifications.Common;

namespace Ordering.Infrastructure.Specifications.UserSpecification;

public class UserByIdSpecification
    : GetByIdSpecification<User>
{
    public UserByIdSpecification(string id)
        : base(id)
    {
    }
}
