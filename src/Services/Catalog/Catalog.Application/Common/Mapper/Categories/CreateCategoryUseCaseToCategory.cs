using AutoMapper;
using Catalog.Application.UseCases.Categories.CreateCategory;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper.Categories;

public class CreateCategoryUseCaseToCategory : Profile
{
    public CreateCategoryUseCaseToCategory()
    {
        CreateMap<CreateCategoryUseCase, Category>()
            .ForMember(
                category => category.Name,
                opt => opt.MapFrom(updateCategoryUseCase => updateCategoryUseCase.CategoryName))
            .ForMember(
                category => category.NormalizedName,
                opt => opt.MapFrom(updateCategoryUseCase => updateCategoryUseCase.CategoryName.ToUpper()));
    }
}
