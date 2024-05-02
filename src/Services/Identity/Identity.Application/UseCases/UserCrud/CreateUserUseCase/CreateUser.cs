using MediatR;

namespace Identity.Application.UseCases.UserCrud.CreateUserUseCase
{
    public class CreateUser : IRequest<string>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }

        public string Role { get; set; }
    }
}
