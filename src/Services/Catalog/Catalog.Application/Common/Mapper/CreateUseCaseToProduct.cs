using AutoMapper;
using Catalog.Application.UseCases.Product.CreateProduct;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class CreateUseCaseToProduct : Profile
{
    public CreateUseCaseToProduct()
    {
        CreateMap<CreateProductUseCase, Product>()
            .ForMember(product => product.Name, 
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Name))
            .ForMember(product => product.Description, 
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Description))
            .ForMember(product => product.Price, 
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Price))
            .ForMember(product => product.StockCount, 
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.StockCount));
    }
}
