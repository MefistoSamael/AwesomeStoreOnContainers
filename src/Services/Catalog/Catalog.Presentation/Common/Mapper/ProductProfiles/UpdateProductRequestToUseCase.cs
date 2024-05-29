using AutoMapper;
using Catalog.Application.UseCases.Product.UpdateProduct;
using Catalog.Presentation.Requests.ProductRequests;

namespace Catalog.Presentation.Common.Mapper.ProductProfiles;

public class UpdateProductRequestToUseCase : Profile
{
    public UpdateProductRequestToUseCase()
    {
        CreateMap<UpdateProductRequest, UpdateProductUseCase>()
            .ForMember(updateProductUseCase => updateProductUseCase.Name,
                opt => opt.MapFrom(updateProductRequest => updateProductRequest.Name))
            .ForMember(updateProductUseCase => updateProductUseCase.Description,
                opt => opt.MapFrom(updateProductRequest => updateProductRequest.Description))
            .ForMember(updateProductUseCase => updateProductUseCase.Price, 
                opt => opt.MapFrom(updateProductRequest => updateProductRequest.Price));
    }
}

