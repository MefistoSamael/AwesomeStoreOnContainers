using AutoMapper;
using Ordering.Application.OrderItems.Commands.UpdateOrderItemQuantityCommand;
using Ordering.Presentation.Common.Requests;

namespace Ordering.Presentation.Common.Mapper.OrderItems;

public class UpdateOrderItemQuantityRequestToCommand : Profile
{
    public UpdateOrderItemQuantityRequestToCommand()
    {
        CreateMap<UpdateOrderItemQuantityRequest, UpdateOrderItemQuantityCommand>()
            .ForMember(command => command.NewQuantity, opt => opt.MapFrom(request => request.NewQuantity))
            .ForMember(command => command.OrderItemId, opt => opt.Ignore());
    }
}