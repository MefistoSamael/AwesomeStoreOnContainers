using AutoMapper;
using Catalog.Application.UseCases.Product.UpdateProduct;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class UpdateUseCaseToProduct : Profile
{
    public UpdateUseCaseToProduct()
    {
        CreateMap<UpdateProductUseCase, Product>()
            .ForMember(product => product.Name,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Name))
            .ForMember(product => product.Description,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Description))
            .ForMember(product => product.Price,
                opt => opt.MapFrom(createProductUseCase => createProductUseCase.Price));
    }
}
