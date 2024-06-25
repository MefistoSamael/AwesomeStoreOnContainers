using AutoMapper;
using Contracts.DTO;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.DTOs;

public class OrderItemToOrderProductDTO : Profile
{
    public OrderItemToOrderProductDTO()
    {
        CreateMap<OrderItem, OrderProductDTO>()
            .ForMember(dest => dest.ProductId, opt => opt.MapFrom(src => src.ProductId))
            .ForMember(dest => dest.PurchasedAmount, opt => opt.MapFrom(src => src.Quantity));
    }
}
