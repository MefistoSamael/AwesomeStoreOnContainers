using AutoMapper;
using Contracts.Messages.IdentityMessages;
using Ordering.Domain.Entities;

namespace Ordering.Application.Common.Mapper.Messages;

public class BuyerCreatedEventToBuyer : Profile
{
    public BuyerCreatedEventToBuyer()
    {
        CreateMap<BuyerCreatedMessage, Buyer>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.BuyerId))
            .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.BuyerEmail));
    }
}