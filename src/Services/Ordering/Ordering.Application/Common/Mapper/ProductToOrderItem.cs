using AutoMapper;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper;

public class ProductToOrderItem : Profile
{
    public ProductToOrderItem()
    {
        CreateMap<Product, OrderItem>()
            .ForMember(orderItem => orderItem.ProductName, opt => opt.MapFrom(product => product.Name))
            .ForMember(orderItem => orderItem.ImageUri, opt => opt.MapFrom(product => product.ImageUri))
            .ForMember(orderItem => orderItem.Price, opt => opt.MapFrom(product => product.Price))
            .ForMember(orderItem => orderItem.ProductId, opt => opt.MapFrom(product => product.Id))
            
            .ForMember(orderItem => orderItem.Id, opt => opt.Ignore())
            .ForMember(orderItem => orderItem.Quantity, opt => opt.Ignore())
            .ForMember(orderItem => orderItem.OrderId, opt => opt.Ignore());
    }
}
