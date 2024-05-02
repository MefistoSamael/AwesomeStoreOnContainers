﻿using MediatR;

namespace Identity.Application.UseCases.Authentication.LogInUseCase
{
    public class LogIn : IRequest<string>
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public string Email { get; set; }
    }
}
