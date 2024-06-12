using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper.Products;

public class ProductToDTO : Profile
{
    public ProductToDTO()
    {
        CreateMap<Product, ProductDTO>()
            .ForMember(productDTO => productDTO.Id, opt => opt.MapFrom(product => product.Id))
            .ForMember(productDTO => productDTO.Name, opt => opt.MapFrom(product => product.Name))
            .ForMember(productDTO => productDTO.Description, opt => opt.MapFrom(product => product.Description))
            .ForMember(productDTO => productDTO.Price, opt => opt.MapFrom(product => product.Price))
            .ForMember(productDTO => productDTO.StockCount, opt => opt.MapFrom(product => product.StockCount))
            .ForMember(productDTO => productDTO.ImageUri, opt => opt.MapFrom(product => product.ImageUri))
            .ForMember(productDTO => productDTO.ProductCatrgories, opt => opt.MapFrom(product => product.Categories));
    }
}
