using AutoMapper;
using Catalog.Application.UseCases.Products.ChangeProductImage;
using Catalog.Presentation.Requests.ProductRequests;

namespace Catalog.Presentation.Common.Mapper.ProductProfiles;

public class ChangeProductImageRequestToUseCase : Profile
{
    public ChangeProductImageRequestToUseCase()
    {
        CreateMap<ChangeProductImageRequest, ChangeProductImageUseCase>()
            .ForMember(
                changeProductImageUseCase => changeProductImageUseCase.Image,
                opt => opt.MapFrom(changeProductImageRequest => changeProductImageRequest.Image));
    }
}
