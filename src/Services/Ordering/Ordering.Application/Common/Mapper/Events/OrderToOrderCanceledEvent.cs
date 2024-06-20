using AutoMapper;
using Contracts.Events.OrderingEvents;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Events;

public class OrderToOrderCanceledEvent : Profile
{
    public OrderToOrderCanceledEvent()
    {
        CreateMap<Order, OrderCanceledEvent>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}