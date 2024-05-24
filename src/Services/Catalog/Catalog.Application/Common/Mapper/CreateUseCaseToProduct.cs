using AutoMapper;
using Catalog.Application.UseCases.Product.CreateProduct;
using Catalog.Domain.Entities;

namespace Catalog.Application.Common.Mapper;

public class CreateUseCaseToProduct : Profile
{
    public CreateUseCaseToProduct()
    {
        CreateMap<CreateProductUseCase, Product>();
    }
}
