using System.Runtime.Serialization;

namespace Catalog.Application.UseCases.Product.CreateProduct;

internal class NotExistingCategoryException : Exception
{
    public NotExistingCategoryException()
    {
    }

    public NotExistingCategoryException(string? message) : base(message)
    {
    }

    public NotExistingCategoryException(string? message, Exception? innerException) : base(message, innerException)
    {
    }
}