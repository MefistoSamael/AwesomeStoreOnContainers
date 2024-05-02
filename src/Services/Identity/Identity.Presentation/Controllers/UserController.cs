using Identity.Application.UseCases.Authentication.LogInUseCase;
using Identity.Application.UseCases.Authentication.RegisterUseCase;
using Identity.Presentation.Model;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
           var token = await _mediator.Send(new LogIn() { UserName = request.Username, Email = request.Email, Password = request.Password});

            return token is not null ? Ok(token) : BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(new Register() { UserName = request.Username, Email = request.Email, Password = request.Password });

            return token is not null ? Ok(token) : BadRequest();
        }

    }
}
