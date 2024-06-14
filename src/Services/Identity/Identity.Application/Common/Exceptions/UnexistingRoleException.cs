using System.Runtime.Serialization;

namespace Identity.Application.Common.Exceptions;

public class UnexistingRoleException : Exception
{
    public UnexistingRoleException()
    {
    }

    public UnexistingRoleException(string? message) : base(message)
    {
    }

    public UnexistingRoleException(string? message, Exception? innerException) : base(message, innerException)
    {
    }

    protected UnexistingRoleException(SerializationInfo info, StreamingContext context) : base(info, context)
    {
    }
}