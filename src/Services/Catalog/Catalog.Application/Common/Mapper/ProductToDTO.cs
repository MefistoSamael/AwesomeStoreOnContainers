using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class ProductToDTO : Profile
{
    public ProductToDTO()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(productDTO => productDTO.Id, opt => opt.MapFrom(product => product.Id))
            .ForMember(productDTO => productDTO.Name, opt => opt.MapFrom(product => product.Name))
            .ForMember(productDTO => productDTO.Price, opt => opt.MapFrom(product => product.Price))
            .ForMember(productDTO => productDTO.StockCount, opt => opt.MapFrom(product => product.StockCount))
            .ForMember(productDTO => productDTO.ProductCatrgories, opt => opt.MapFrom(product => product.Categories));
    }
}
