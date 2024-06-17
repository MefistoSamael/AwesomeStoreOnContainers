using AutoMapper;
using Ordering.Application.Common.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper;

public class OrderToDTO : Profile
{
    public OrderToDTO()
    {
        CreateMap<Order, OrderDTO>()
            .ForMember(orderDTO => orderDTO.Id, opt => opt.MapFrom(order => order.Id))
            .ForMember(orderDTO => orderDTO.Description, opt => opt.MapFrom(order => order.Description))
            .ForMember(orderDTO => orderDTO.OrderItems, opt => opt.MapFrom(order => order.OrderItems))
            .ForMember(orderDTO => orderDTO.State, opt => opt.MapFrom(order => order.State.ToString()));
    }
}
