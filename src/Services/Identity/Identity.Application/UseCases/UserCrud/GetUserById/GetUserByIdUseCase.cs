using Identity.Application.Common.Models;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetUserById;

public class GetUserByIdUseCase : IRequest<UserDTO?>
{
    required public string UserId { get; set; }
}
