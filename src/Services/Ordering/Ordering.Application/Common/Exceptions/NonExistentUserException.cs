using System.Runtime.Serialization;

namespace Ordering.Application.Common.Exceptions;

internal class NonExistentUserException : Exception
{
    public NonExistentUserException()
    {
    }

    public NonExistentUserException(string? message)
        : base(message)
    {
    }

    public NonExistentUserException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }

    protected NonExistentUserException(SerializationInfo info, StreamingContext context)
        : base(info, context)
    {
    }
}