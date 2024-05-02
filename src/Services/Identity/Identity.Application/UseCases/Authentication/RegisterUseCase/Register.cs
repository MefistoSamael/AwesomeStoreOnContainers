using MediatR;

namespace Identity.Application.UseCases.Authentication.RegisterUseCase
{
    public class Register : IRequest<string>
    {
        public string UserName;

        public string Password;

        public string Email;
    }
}
