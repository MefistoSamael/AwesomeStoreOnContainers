using AutoMapper;
using grpcProductResponse = Ordering.Infrastructure.Protos.ProductResponse;
using ProductResponse = Ordering.Application.Common.Models.ProductResponse;

namespace Ordering.Infrastructure.Mapper;

public class ProductToProductResponseProfile : Profile
{
    public ProductToProductResponseProfile()
    {
        CreateMap<grpcProductResponse, ProductResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ImageUri, opt => opt.MapFrom(src => src.ImageUri))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Categoties, opt => opt.MapFrom(src => src.Categories));
    }
}
