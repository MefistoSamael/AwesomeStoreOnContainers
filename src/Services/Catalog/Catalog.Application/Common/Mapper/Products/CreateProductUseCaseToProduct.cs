using AutoMapper;
using Catalog.Application.UseCases.Products.CreateProduct;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper.Products;

public class CreateProductUseCaseToProduct : Profile
{
    public CreateProductUseCaseToProduct()
    {
        CreateMap<CreateProductUseCase, Product>()
            .ForMember(
                product => product.Name,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Name))
            .ForMember(
                product => product.Description,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Description))
            .ForMember(
                product => product.Price,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Price))
            .ForMember(
                product => product.StockCount,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.StockCount))
            .ForMember(
                product => product.Categories,
                opt => opt.Ignore())
            .ForMember(
                product => product.ImageFileName,
                opt => opt.Ignore())
            .ForMember(
                product => product.ImageUri,
                opt => opt.Ignore());
    }
}
