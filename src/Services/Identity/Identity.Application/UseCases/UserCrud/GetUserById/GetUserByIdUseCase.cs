using Identity.Application.Models;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetUserById;

public class GetUserByIdUseCase : IRequest<UserDTO?>
{
    public string UserId { get; set; }
}
