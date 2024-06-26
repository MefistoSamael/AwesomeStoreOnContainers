using AutoMapper;
using Catalog.Domain.Entities;
using Catalog.Infrastructure.Protos;

namespace Catalog.Infrastructure.Mapper;

public class ProductToProductResponse : Profile
{
    public ProductToProductResponse()
    {
        CreateMap<Product, ProductResponse>()
            .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name))
            .ForMember(dest => dest.ImageUri, opt => opt.MapFrom(src => src.ImageUri))
            .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Price))
            .ForMember(dest => dest.Categories, opt => opt.MapFrom(src => string.Join(", ", src.Categories.Select(c => c.Name))));
    }
}
