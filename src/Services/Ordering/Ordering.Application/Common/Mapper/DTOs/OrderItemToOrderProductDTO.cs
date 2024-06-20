using AutoMapper;
using Contracts.DTO;
using Contracts.OrderingEvents;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.DTOs;

public class OrderToOrderCanceledEvent : Profile
{
    public OrderToOrderCanceledEvent()
    {
        CreateMap<OrderItem, OrderProductDTO>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.PurchasedAmount, opt => opt.MapFrom(src => src.Quantity));
    }
}
