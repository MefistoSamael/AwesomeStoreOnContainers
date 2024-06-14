using System.Runtime.Serialization;

namespace Ordering.Application.Common.Exceptions;
public class ExistingOrderItemException : Exception
{
    public ExistingOrderItemException()
    {
    }

    public ExistingOrderItemException(string? message) : base(message)
    {
    }

    public ExistingOrderItemException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}