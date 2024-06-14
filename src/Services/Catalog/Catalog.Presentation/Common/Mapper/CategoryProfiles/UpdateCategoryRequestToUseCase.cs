using AutoMapper;
using Catalog.Application.UseCases.Categories.UpdateCategory;
using Catalog.Presentation.Requests.CategoryRequests;

namespace Catalog.Presentation.Common.Mapper.CategoryProfiles;

public class UpdateCategoryRequestToUseCase : Profile
{
    public UpdateCategoryRequestToUseCase()
    {
        CreateMap<UpdateCategoryRequest, UpdateCategoryUseCase>()
            .ForMember(
                createCategoryUseCase => createCategoryUseCase.CategoryName,
                opt => opt.MapFrom(createCategoryRequest => createCategoryRequest.NewCategoryName));
    }
}
