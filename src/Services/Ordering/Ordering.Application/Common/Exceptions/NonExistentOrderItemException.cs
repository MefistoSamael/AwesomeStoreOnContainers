using System.Runtime.Serialization;

namespace Ordering.Application.Common.Exceptions;
[Serializable]
internal class NonExistentOrderItemException : Exception
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