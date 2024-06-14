using AutoMapper;
using Ordering.Application.Common.Models;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper;

public class OrderItemToDTO : Profile
{
    public OrderItemToDTO()
    {
        CreateMap<OrderItem, OrderItemDTO>()
            .ForMember(orderItemDTO => orderItemDTO.Id, opt => opt.MapFrom(orderItem => orderItem.Id))
            .ForMember(orderItemDTO => orderItemDTO.ProductName, opt => opt.MapFrom(orderItem => orderItem.ProductName))
            .ForMember(orderItemDTO => orderItemDTO.ImageUri, opt => opt.MapFrom(orderItem => orderItem.ImageUri))
            .ForMember(orderItemDTO => orderItemDTO.Price, opt => opt.MapFrom(orderItem => orderItem.Price))
            .ForMember(orderItemDTO => orderItemDTO.Quantity, opt => opt.MapFrom(orderItem => orderItem.Quantity));
    }
}
