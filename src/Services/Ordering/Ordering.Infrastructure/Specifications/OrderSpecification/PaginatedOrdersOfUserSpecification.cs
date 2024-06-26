namespace Ordering.Infrastructure.Specifications.OrderSpecification;

public class PaginatedOrdersOfUserSpecification : PaginatedOrdersSpecification
{
    public PaginatedOrdersOfUserSpecification(int pageNumber, int pageSize, string id)
        : base(pageNumber, pageSize)
    {
        AddCriteria(order => order.BuyerId == id);
    }
}
