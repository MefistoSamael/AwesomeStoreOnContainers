using AutoMapper;
using Catalog.Application.Common.Exceptions;
using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
using Catalog.Domain.Entities;
using MediatR;

namespace Catalog.Application.UseCases.Products.CreateProduct;

public class CreateProductInteractor : IRequestHandler<CreateProductUseCase, string>
{
    private readonly IProductRepostitory _productRepository;
    private readonly IImageService _imageService;
    private readonly IMapper _mapper;
    private readonly ICategoryRepository _categoryRepository;

    public CreateProductInteractor(
        IProductRepostitory productRepository,
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
        List<Category> domainCategories = [];

        foreach (string category in request.Categories)
        {
            Category? domainCategory = await _categoryRepository.GetByNameAsync(category, cancellationToken);

            if (domainCategory is null)
            {
                throw new NonExistentCategoryException($"category with name: {category} doesn't exist");
            }

            domainCategories.Add(domainCategory);
        }

        Product product = _mapper.Map<Product>(request);

        product.Id = await _productRepository.CreateAsync(product, cancellationToken);

        product = await _imageService.SaveImageAsync(request.Image, product, cancellationToken);

        product.Categories = domainCategories;

        await _productRepository.UpdateAsync(product, cancellationToken);

        return product.Id;
    }
}
