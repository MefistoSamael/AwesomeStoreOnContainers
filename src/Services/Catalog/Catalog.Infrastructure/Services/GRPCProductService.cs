using AutoMapper;
using Catalog.Domain.Abstractions;
using Catalog.Infrastructure.Protos;
using Grpc.Core;

namespace Catalog.Infrastructure.Services;

public class GRPCProductService : GRPCProduct.GRPCProductBase
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;

    public GRPCProductService(IProductRepostitory productRepostitory, IMapper mapper)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
    }

    public override async Task<ProductResponse?> GetProductById(Request request, ServerCallContext context)
    {
        var product = await _productRepostitory.GetByIdAsync(request.ProductId, default);

        if (product is null)
        {
            return null;
        }

        return _mapper.Map<ProductResponse>(product);
    }
}
