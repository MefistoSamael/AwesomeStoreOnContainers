using AutoMapper;
using Contracts.Events.IdentityEvents;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Events;

public class BuyerCreatedEventToBuyer : Profile
{
    public BuyerCreatedEventToBuyer()
    {
        CreateMap<BuyerCreatedEvent, Buyer>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BuyerId))
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.BuyerFullName));
    }
}