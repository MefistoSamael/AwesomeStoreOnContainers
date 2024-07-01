namespace Ordering.Application.Common.Exceptions;
public class NonExistentProductException : Exception
{
    public NonExistentProductException()
    {
    }

    public NonExistentProductException(string? message)
        : base(message)
    {
    }

    public NonExistentProductException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}