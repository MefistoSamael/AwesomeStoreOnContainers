using AutoMapper;
using Ordering.Application.OrderItems.Commands.AddOrderItemToOrderCommand;
using Ordering.Presentation.Common.Requests;

namespace Ordering.Presentation.Common.Mapper.OrderItems;

public class AddProductToOrderRequestToCommand : Profile
{
    public AddProductToOrderRequestToCommand()
    {
        CreateMap<AddProductToOrderRequest, AddProductToOrderCommand>()
            .ForMember(command => command.ProductId, opt => opt.MapFrom(request => request.ProductId))
            .ForMember(command => command.Quantity, opt => opt.MapFrom(request => request.Quantity))
            .ForMember(command => command.OrderId, opt => opt.MapFrom(request => request.OrderId));
    }
}