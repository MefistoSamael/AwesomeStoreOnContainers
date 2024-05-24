using AutoMapper;
using Catalog.Application.Services;
using Catalog.Domain.Abstractions;
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
        foreach (var category in request.Categories)
        {
            if ((await _categoryRepository.GetCategoryByNameAsync(category)) is null)
            {
                throw new NotExistingCategoryException();
            }
        }

        var product = _mapper.Map<Domain.Entities.Product>(request);

        product.Id = await _productRepository.CreateProductAsync(product);

        product = await _imageService.SaveImageAsync(request.Image, product);
        
        await _productRepository.AddToCategoriesAsync(product, request.Categories);

        return product.Id;
    }
}
