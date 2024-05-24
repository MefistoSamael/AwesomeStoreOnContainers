using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class CategoryToDTO : Profile
{
    public CategoryToDTO()
    {
        CreateMap<Category, CategoryDTO>();
    }
}
