using AutoMapper;
using Contracts.Messages.OrderingMessages;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Events;

public class OrderToOrderCanceledEvent : Profile
{
    public OrderToOrderCanceledEvent()
    {
        CreateMap<Order, OrderCanceledMessage>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}