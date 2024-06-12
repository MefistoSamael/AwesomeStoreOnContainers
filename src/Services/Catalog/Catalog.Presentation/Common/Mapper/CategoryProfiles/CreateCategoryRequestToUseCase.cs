using AutoMapper;
using Catalog.Application.UseCases.Categories.CreateCategory;
using Catalog.Presentation.Requests.CategoryRequests;

namespace Catalog.Presentation.Common.Mapper.CategoryProfiles;

public class CreateCategoryRequestToUseCase : Profile
{
    public CreateCategoryRequestToUseCase()
    {
        CreateMap<CreateCategoryRequest, CreateCategoryUseCase>()
            .ForMember(createCategoryUseCase => createCategoryUseCase.CategoryName,
                opt => opt.MapFrom(createCategoryRequest => createCategoryRequest.CategoryName));
    }
}

