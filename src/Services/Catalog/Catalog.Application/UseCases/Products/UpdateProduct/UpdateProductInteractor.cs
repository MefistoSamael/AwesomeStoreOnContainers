using AutoMapper;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Product.UpdateProduct;

public class UpdateProductInteractor : IRequestHandler<UpdateProductUseCase, string>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;

    public UpdateProductInteractor(IProductRepostitory productRepostitory, IMapper mapper)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
    }

    public async Task<string> Handle(UpdateProductUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException($"product with {request.ProductId} id not found");
        }

        product = _mapper.Map(request, product);

        await _productRepostitory.UpdateProductAsync(product, cancellationToken);

        return product.Id;
    }
}
