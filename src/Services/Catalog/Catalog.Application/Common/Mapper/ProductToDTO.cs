using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class ProductToDTO : Profile
{
    public ProductToDTO()
    {
        CreateMap<Product, ProductDTO>();
    }
}
