using System.Runtime.Serialization;

namespace Ordering.Application.OrderItems.Queries.GetOrderItemsFromOrderQuery;
public class NonExistentOrderException : Exception
{
    public NonExistentOrderException()
    {
    }

    public NonExistentOrderException(string? message) : base(message)
    {
    }

    public NonExistentOrderException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}