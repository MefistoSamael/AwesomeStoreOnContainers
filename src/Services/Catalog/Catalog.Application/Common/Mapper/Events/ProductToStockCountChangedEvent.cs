using AutoMapper;
using Catalog.Application.Common.Events;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper.Events;

public class ProductToStockCountChangedEvent : Profile
{
    public ProductToStockCountChangedEvent()
    {
        CreateMap<Product, StockCountChangedEvent>()
            .ForMember(stockAmountChangedEvent => stockAmountChangedEvent.ProductId,
                opt => opt.MapFrom(product => product.Id))
            .ForMember(stockAmountChangedEvent => stockAmountChangedEvent.ProductName,
                opt => opt.MapFrom(product => product.Name))
            .ForMember(stockAmountChangedEvent => stockAmountChangedEvent.OldStockCount,
                opt => opt.MapFrom(product => product.StockCount));
    }
}
