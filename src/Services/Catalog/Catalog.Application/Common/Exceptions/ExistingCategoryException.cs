using System.Runtime.Serialization;

namespace Catalog.Application.Common.Exceptions;

internal class ExistingCategoryException : Exception
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