namespace Identity.Application.Common.Exceptions;

public class NonExistentUserException : Exception
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
}