using AutoMapper;
using Catalog.Application.Common.Events;
using Catalog.Domain.Abstractions;
using EventBus.Domain.Interfaces;
using MediatR;

namespace Catalog.Application.UseCases.Products.UpdateProduct;

public class UpdateProductInteractor : IRequestHandler<UpdateProductUseCase, string>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;
    private readonly IEventBus _eventBus;

    public UpdateProductInteractor(IProductRepostitory productRepostitory, IMapper mapper, IEventBus eventBus)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
        _eventBus = eventBus;
    }

    public async Task<string> Handle(UpdateProductUseCase request, CancellationToken cancellationToken)
    {
        var product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException($"product with {request.ProductId} id not found");
        }

        var priceChangedEvent = _mapper.Map<PriceChangedEvent>(product);
        priceChangedEvent.NewPrice = request.Price;

        product = _mapper.Map(request, product);

        await _productRepostitory.UpdateProductAsync(product, cancellationToken);

        //_eventBus.Publish(priceChangedEvent);

        return product.Id;
    }
}
