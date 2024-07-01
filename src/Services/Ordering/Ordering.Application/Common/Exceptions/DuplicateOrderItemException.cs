namespace Ordering.Application.Common.Exceptions;
public class DuplicateOrderItemException : Exception
{
    public DuplicateOrderItemException()
    {
    }

    public DuplicateOrderItemException(string? message)
        : base(message)
    {
    }

    public DuplicateOrderItemException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}