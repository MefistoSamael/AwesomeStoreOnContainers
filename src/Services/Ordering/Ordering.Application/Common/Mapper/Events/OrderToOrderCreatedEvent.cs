using AutoMapper;
using Contracts.Messages.OrderingMessages;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Events;

public class OrderToOrderConfiguredEvent : Profile
{
    public OrderToOrderConfiguredEvent()
    {
        CreateMap<Order, OrderConfiguredMessage>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}
