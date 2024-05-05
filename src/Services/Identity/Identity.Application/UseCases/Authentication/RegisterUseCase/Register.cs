using MediatR;

namespace Identity.Application.UseCases.Authentication.RegisterUseCase
{
    public class Register : IRequest<string>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
