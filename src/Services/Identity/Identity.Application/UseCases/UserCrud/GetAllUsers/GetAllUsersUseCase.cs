using Identity.Application.Models;
using MediatR;

namespace Identity.Application.UseCases.UserCrud.GetAllUsers;

public class GetAllUsersUseCase : IRequest<IEnumerable<UserDTO>>
{
}
