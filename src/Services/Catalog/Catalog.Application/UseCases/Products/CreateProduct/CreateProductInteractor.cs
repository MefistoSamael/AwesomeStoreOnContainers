using AutoMapper;
using Catalog.Application.Common.Exceptions;
using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.UseCases.Product.CreateProduct;

public class CreateProductInteractor : IRequestHandler<CreateProductUseCase, string>
{
    private readonly IProductRepostitory _productRepository;
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProductInteractor(IProductRepostitory productRepository,
                                   IImageService imageService,
                                   IMapper mapper,
                                   ICategoryRepository categoryRepository)
    {
        _productRepository = productRepository;
        _imageService = imageService;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<string> Handle(CreateProductUseCase request, CancellationToken cancellationToken)
    {
        List<Category> domainCategories = new();

        foreach (var category in request.Categories)
        {
            var domainCategory = await _categoryRepository.GetCategoryByNameAsync(category, cancellationToken);
            
            if (domainCategory is null)
            {
                throw new NonExistentCategoryException();
            }

            domainCategories.Add(domainCategory);
        }

        var product = _mapper.Map<Domain.Entities.Product>(request);

        product.Id = await _productRepository.CreateProductAsync(product, cancellationToken);

        product = await _imageService.SaveImageAsync(request.Image, product, cancellationToken);
        
        await _productRepository.AddToCategoriesAsync(product, domainCategories, cancellationToken);

        return product.Id;
    }
}
