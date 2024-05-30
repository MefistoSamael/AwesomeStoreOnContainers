using Catalog.Application.Common.Exceptions;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;
using System.Runtime.CompilerServices;

namespace Catalog.Application.UseCases.Products.ChangeProductCategories;

public class ChangeProductCategoriesInteractor : IRequestHandler<ChangeProductCategoriesUseCase, string>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly ICategoryRepository _categoryRepository;

    public ChangeProductCategoriesInteractor(IProductRepostitory productRepostitory, ICategoryRepository categoryRepository)
    {
        _productRepostitory = productRepostitory;
        _categoryRepository = categoryRepository;
    }

    public async Task<string> Handle(ChangeProductCategoriesUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken) 
            ?? throw new KeyNotFoundException("product with specified id wasn't found");

        var domainCategories = new List<Category>();

        foreach (var category in request.Categories)
        {
            domainCategories.Add(await _categoryRepository.GetCategoryByNameAsync(category, cancellationToken)
                ?? throw new NonExistentCategoryException($"there are no category with {category} name"));
        }

        await _productRepostitory.RemoveFromCategoriesAsync(product, new List<Category>(product.Categories), cancellationToken);
        
        await _productRepostitory.AddToCategoriesAsync(product, domainCategories, cancellationToken);

        return product.Id;
    }
}
