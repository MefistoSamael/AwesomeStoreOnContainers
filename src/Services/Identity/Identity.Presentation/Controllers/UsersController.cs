using Identity.Application.UseCases.Authentication.LogInUseCase;
using Identity.Application.UseCases.Authentication.RegisterUseCase;
using Identity.Application.UseCases.UserCrud.ChangeRoleUseCase;
using Identity.Application.UseCases.UserCrud.CreateUserUseCase;
using Identity.Application.UseCases.UserCrud.DeleteUserUseCase;
using Identity.Application.UseCases.UserCrud.GetAllUsersUseCase;
using Identity.Application.UseCases.UserCrud.GetUserByIdUseCase;
using Identity.Presentation.Requests.AuthenticationRequests;
using Identity.Presentation.Requests.UserRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
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
        public async Task<IActionResult> Login([FromBody] LogInRequest request, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(new LogIn 
            { 
                Email = request.Email, 
                Password = request.Password,
                UserName = request.UserName,
            }, cancellationToken);

            return token is not null ? Ok(token) : BadRequest();
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterRequest request, CancellationToken cancellationToken)
        {
            var token = await _mediator.Send(new Register
            {
                Email = request.Email,
                Password = request.Password,
                UserName = request.UserName,
            }, cancellationToken);

            return token is not null ? Ok(token) : BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateUser
            {
                UserName = request.UserName,
                Email = request.Email,
                Password = request.Password,
                Role = request.Role,
            }, cancellationToken);

            return id is not null ? Ok(id) : BadRequest();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteUser(string id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteUser { Id = id }, cancellationToken);

            return Ok();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
        {
            var users = await _mediator.Send(new GetAllUsers(), cancellationToken);

            return users is not null ? Ok(users) : NotFound();
        }

        [HttpGet]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetUserById(string id, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new GetUserById { UserId = id}, cancellationToken);

            return user is not null ? Ok(user) : NotFound();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ChangeUserRole(string id, [FromBody] ChangeUserRoleRequest request, CancellationToken cancellationToken)
        {
            var user = await _mediator.Send(new ChangeRole { UserId = id, RoleName = request.NewRole}, cancellationToken);

            return user is not null ? Ok(user) : NotFound();
        }
    }
}
