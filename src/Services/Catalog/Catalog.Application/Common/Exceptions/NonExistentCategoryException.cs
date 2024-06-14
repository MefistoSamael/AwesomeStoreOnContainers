namespace Catalog.Application.Common.Exceptions;

public class NonExistentCategoryException : Exception
{
    public NonExistentCategoryException()
    {
    }

    public NonExistentCategoryException(string? message)
        : base(message)
    {
    }

    public NonExistentCategoryException(string? message, Exception? innerException)
        : base(message, innerException)
    {
    }
}