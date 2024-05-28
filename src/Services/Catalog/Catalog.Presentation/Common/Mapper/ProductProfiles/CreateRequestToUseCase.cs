using AutoMapper;
using Catalog.Application.UseCases.Product.CreateProduct;
using Catalog.Presentation.Requests.ProductRequests;

namespace Catalog.Presentation.Common.Mapper.ProductProfiles;

public class CreateRequestToUseCase : Profile
{
    public CreateRequestToUseCase()
    {
        CreateMap<CreateProductRequest, CreateProductUseCase>()
            .ForMember(us => us.Name, opt => opt.MapFrom(r => r.Name))
            .ForMember(us => us.Description, opt => opt.MapFrom(r => r.Description))
            .ForMember(us => us.Price, opt => opt.MapFrom(r => r.Price))
            .ForMember(us => us.StockCount, opt => opt.MapFrom(r => r.StockCount))
            .ForMember(us => us.Image, opt => opt.MapFrom(r => r.Image))
            .ForMember(us => us.Categories, opt => opt.MapFrom(r => r.Categories))
            ;
    }
}

