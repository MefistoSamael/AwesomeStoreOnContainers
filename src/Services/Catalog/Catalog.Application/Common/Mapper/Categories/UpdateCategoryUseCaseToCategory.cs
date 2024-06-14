using AutoMapper;
using Catalog.Application.UseCases.Categories.UpdateCategory;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper.Categories;

public class UpdateCategoryUseCaseToCategory : Profile
{
    public UpdateCategoryUseCaseToCategory()
    {
        CreateMap<UpdateCategoryUseCase, Category>()
            .ForMember(
                category => category.Name,
                opt => opt.MapFrom(updateCategoryUseCase => updateCategoryUseCase.CategoryName))
            .ForMember(
                category => category.NormalizedName,
                opt => opt.MapFrom(updateCategoryUseCase => updateCategoryUseCase.CategoryName.ToUpper()));
    }
}
