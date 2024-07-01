using AutoMapper;
using Contracts.Messages.OrderingMessages;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Messages;

public class OrderToOrderConfiguredMessage : Profile
{
    public OrderToOrderConfiguredMessage()
    {
        CreateMap<Order, OrderConfiguredMessage>()
            .ForMember(dest => dest.OrderItems, opt => opt.MapFrom(src => src.OrderItems));
    }
}
