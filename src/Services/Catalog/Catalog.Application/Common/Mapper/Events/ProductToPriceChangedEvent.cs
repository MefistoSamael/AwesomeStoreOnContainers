using AutoMapper;
using Catalog.Application.Common.Events;
using Catalog.Domain.Entities;
using System.Net;

namespace Catalog.Application.Common.Mapper.Events;

public class ProductToPriceChangedEvent : Profile
{
    public ProductToPriceChangedEvent()
    {
        CreateMap<Product, PriceChangedEvent>()
            .ForMember(priceChangedEvent => priceChangedEvent.ProductId,
                opt => opt.MapFrom(product => product.Id))
            .ForMember(priceChangedEvent => priceChangedEvent.ProductName,
                opt => opt.MapFrom(product => product.Name))
            .ForMember(priceChangedEvent => priceChangedEvent.OldPrice,
                opt => opt.MapFrom(product => product.Price));
    }
}
