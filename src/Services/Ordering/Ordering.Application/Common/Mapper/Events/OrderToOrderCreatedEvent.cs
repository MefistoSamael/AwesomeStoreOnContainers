using AutoMapper;
using Contracts.DTO;
using Contracts.Events.OrderingEvents;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Events;

public class OrderToOrderConfiguredEvent : Profile
{
    public OrderToOrderConfiguredEvent()
    {
        CreateMap<Order, OrderConfiguredEvent>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}
