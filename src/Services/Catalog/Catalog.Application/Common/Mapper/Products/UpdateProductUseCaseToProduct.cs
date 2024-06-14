using AutoMapper;
using Catalog.Application.UseCases.Products.UpdateProduct;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper.Products;

public class UpdateProductUseCaseToProduct : Profile
{
    public UpdateProductUseCaseToProduct()
    {
        CreateMap<UpdateProductUseCase, Product>()
            .ForMember(
                product => product.Name,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Name))
            .ForMember(
                product => product.Description,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Description))
            .ForMember(
                product => product.Price,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Price));
    }
}
