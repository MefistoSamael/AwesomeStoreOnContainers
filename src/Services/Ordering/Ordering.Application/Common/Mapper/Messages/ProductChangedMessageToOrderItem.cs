using AutoMapper;
using Contracts.Messages.CatalogMessages;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Messages;

public class ProductChangedMessageToOrderItem : Profile
{
    public ProductChangedMessageToOrderItem()
    {
        CreateMap<ProductChangedMessage, OrderItem>()
            .ForMember(item => item.ProductId, opt => opt.MapFrom(message => message.ProductId))
            .ForMember(item => item.ProductName, opt => opt.MapFrom(message => message.ProductName))
            .ForMember(item => item.Quantity, opt => opt.MapFrom(message => message.StockCount))
            .ForMember(item => item.ImageUri, opt => opt.MapFrom(message => message.ImageUri))
            .ForMember(item => item.Price, opt => opt.MapFrom(message => message.Price));
    }
}
