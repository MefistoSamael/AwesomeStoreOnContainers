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
}