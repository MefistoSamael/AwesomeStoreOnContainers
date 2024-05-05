using Identity.Application.UseCases.Authentication.LogInUseCase;
using Identity.Application.UseCases.Authentication.RegisterUseCase;
using Identity.Application.UseCases.UserCrud.CreateUserUseCase;
using Identity.Application.UseCases.UserCrud.DeleteUserUseCase;
using Identity.Application.UseCases.UserCrud.GetAllUsersUseCase;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LogIn request, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(request, cancellationToken);

            return token is not null ? Ok(token) : BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] Register request, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(request, cancellationToken);

            return token is not null ? Ok(token) : BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(request, cancellationToken);

            return id is not null ? Ok(id) : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(string id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUser { Id = id} , cancellationToken);

            return Ok();
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUsers(), cancellationToken);

            return users is not null ? Ok(users) : NotFound();
        }
    }
}
