using AutoMapper;
using Ordering.Application.Orders.Commands.CreateOrder;
using Ordering.Domain.Entities;
using Ordering.Domain.Enums;

namespace Ordering.Application.Common.Mapper.Commands;

public class CreateOrderCommandToOrder : Profile
{
    public CreateOrderCommandToOrder()
    {
        CreateMap<CreateOrderCommand, Order>()
            .ForMember(
                order => order.BuyerId,
                opt => opt.MapFrom(createOrderCommand => createOrderCommand.BuyerId))
            .ForMember(
                order => order.Description,
                opt => opt.MapFrom(createOrderCommand => createOrderCommand.Description))
            .ForMember(
                order => order.State,
                opt => opt.MapFrom(_ => OrderState.Configuring))
            .ForMember(
                order => order.OrderItems,
                opt => opt.MapFrom(_ => new List<OrderItem>()));
    }
}
