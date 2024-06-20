namespace Identity.Application.Common.Exceptions;

public class NonExistentRoleException : Exception
{
    public NonExistentRoleException()
    {
    }

    public NonExistentRoleException(string? message)
        : base(message)
    {
    }

    public NonExistentRoleException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}