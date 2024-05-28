using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Abstractions;
using MediatR;

namespace Catalog.Application.UseCases.Product.GetProductById;

public class GetProductByIdInteractor : IRequestHandler<GetProductByIdUseCase, ProductDTO>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;

    public GetProductByIdInteractor(IProductRepostitory productRepostitory, IMapper mapper)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
    }

    public async Task<ProductDTO> Handle(GetProductByIdUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException($"product with {request.ProductId} id not found");
        }

        return _mapper.Map<ProductDTO>(product);
    }
}
