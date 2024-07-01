namespace Ordering.Application.Common.Exceptions;

public class NonExistentOrderItemException : Exception
{
    public NonExistentOrderItemException()
    {
    }

    public NonExistentOrderItemException(string? message)
        : base(message)
    {
    }

    public NonExistentOrderItemException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}