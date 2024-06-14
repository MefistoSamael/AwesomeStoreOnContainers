using AutoMapper;
using Catalog.Application.UseCases.Products.ChangeProductCategories;
using Catalog.Presentation.Requests.ProductRequests;

namespace Catalog.Presentation.Common.Mapper.ProductProfiles;

public class ChangeProductCategoriesRequestToUseCase : Profile
{
    public ChangeProductCategoriesRequestToUseCase()
    {
        CreateMap<ChangeProductCategoriesRequest, ChangeProductCategoriesUseCase>()
            .ForMember(
                changeProductCategoriesRequest => changeProductCategoriesRequest.Categories,
                opt => opt.MapFrom(changeProductCategoriesUseCase => changeProductCategoriesUseCase.Categories));
    }
}
