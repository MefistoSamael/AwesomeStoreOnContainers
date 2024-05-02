using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.UseCases.Authentication.RegisterUseCase
{
    public class Register : IRequest<string>
    {
        public string UserName;

        public string Password;

        public string Email;
    }
}
