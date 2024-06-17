﻿using AutoMapper;
using Catalog.Domain.Abstractions;
using Contracts;
using MassTransit;
using MediatR;

namespace Catalog.Application.UseCases.Products.UpdateProduct;

public class UpdateProductInteractor : IRequestHandler<UpdateProductUseCase, string>
{
    private readonly IProductRepostitory _productRepostitory;
    private readonly IMapper _mapper;
    private readonly IPublishEndpoint _publishEndpoint;

    public UpdateProductInteractor(
        IProductRepostitory productRepostitory,
        IPublishEndpoint endpoint,
        IMapper mapper)
    {
        _productRepostitory = productRepostitory;
        _mapper = mapper;
        _publishEndpoint = endpoint;
    }

    public async Task<string> Handle(UpdateProductUseCase request, CancellationToken cancellationToken)
    {
        Domain.Entities.Product? product = await _productRepostitory.GetProductByIdAsync(request.ProductId, cancellationToken);

        if (product is null)
        {
            throw new KeyNotFoundException($"product with {request.ProductId} id not found");
        }

        PriceChangedEvent priceChangedEvent = _mapper.Map<PriceChangedEvent>(product);
        priceChangedEvent.NewPrice = request.Price;

        product = _mapper.Map(request, product);

        await _productRepostitory.UpdateProductAsync(product, cancellationToken);

        await _publishEndpoint.Publish(priceChangedEvent);

        return product.Id;
    }
}