using AutoMapper;
using Catalog.Application.Common.Models;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class CategoryToDTO : Profile
{
    public CategoryToDTO()
    {
        CreateMap<Category, CategoryDTO>()
            .ForMember(categoryDTO => categoryDTO.CatrgoryName, opt => opt.MapFrom(category => category.Name))
            .ForMember(categoryDTO => categoryDTO.Id, opt => opt.MapFrom(category => category.Id));
    }
}
