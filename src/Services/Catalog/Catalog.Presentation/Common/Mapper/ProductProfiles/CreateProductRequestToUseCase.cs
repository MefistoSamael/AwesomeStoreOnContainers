using AutoMapper;
using Catalog.Application.UseCases.Product.CreateProduct;
using Catalog.Presentation.Requests.ProductRequests;

namespace Catalog.Presentation.Common.Mapper.ProductProfiles;

public class CreateProductRequestToUseCase : Profile
{
    public CreateProductRequestToUseCase()
    {
        CreateMap<CreateProductRequest, CreateProductUseCase>()
            .ForMember(createProductUseCase => createProductUseCase.Name,
                opt => opt.MapFrom(createProductRequest => createProductRequest.Name))
            .ForMember(createProductUseCase => createProductUseCase.Description,
                opt => opt.MapFrom(createProductRequest => createProductRequest.Description))
            .ForMember(createProductUseCase => createProductUseCase.Price,
                opt => opt.MapFrom(createProductRequest => createProductRequest.Price))
            .ForMember(createProductUseCase => createProductUseCase.StockCount,
                opt => opt.MapFrom(createProductRequest => createProductRequest.StockCount))
            .ForMember(createProductUseCase => createProductUseCase.Image,
                opt => opt.MapFrom(createProductRequest => createProductRequest.Image))
            .ForMember(createProductUseCase => createProductUseCase.Categories,
                opt => opt.MapFrom(createProductRequest => createProductRequest.Categories));
    }
}

