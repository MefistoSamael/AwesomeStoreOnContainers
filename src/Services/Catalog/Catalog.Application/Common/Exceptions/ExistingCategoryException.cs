namespace Catalog.Application.Common.Exceptions;

public class ExistingCategoryException : Exception
{
    public ExistingCategoryException()
    {
    }

    public ExistingCategoryException(string? message) : base(message)
    {
    }

    public ExistingCategoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}