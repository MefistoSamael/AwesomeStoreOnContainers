using AutoMapper;
using Grpc.Net.Client;
using Microsoft.Extensions.Options;
using Ordering.Application.Common.Models;
using Ordering.Application.Services;
using Ordering.Infrastructure.Options;
using Ordering.Infrastructure.Protos;
using ProductResponse = Ordering.Application.Common.Models.ProductResponse;

namespace Ordering.Infrastructure.Services;

public class GRPCProductService : IProductService
{
    private readonly string _grpcServerAddres;
    private readonly IMapper _mapper;

    public GRPCProductService(IMapper mapper, IOptions<GrpcConnectionOptions> options)
    {
        _grpcServerAddres = options.Value.ConnectionString;
        _mapper = mapper;
    }

    public async Task<ProductResponse?> GetProductByIdAsync(string productId)
    {
        using var channel = GrpcChannel.ForAddress(_grpcServerAddres);

        var client = new ProductGRPC.ProductGRPCClient(channel);

        var request = new Request { ProductId = productId };

        var grpcResponse = await client.ProdGetAsync(request);

        var response = _mapper.Map<ProductResponse>(grpcResponse);
        return response;
    }
}
