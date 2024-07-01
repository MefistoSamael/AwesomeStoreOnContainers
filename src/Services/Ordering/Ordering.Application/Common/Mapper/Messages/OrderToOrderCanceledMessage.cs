using AutoMapper;
using Contracts.Messages.OrderingMessages;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Messages;

public class OrderToOrderCanceledMessage : Profile
{
    public OrderToOrderCanceledMessage()
    {
        CreateMap<Order, OrderCanceledMessage>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}