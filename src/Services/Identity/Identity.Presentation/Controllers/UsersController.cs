using AutoMapper;
using Identity.Application.UseCases.Authentication.LogIn;
using Identity.Application.UseCases.Authentication.Register;
using Identity.Application.UseCases.UserCrud.ChangeRole;
using Identity.Application.UseCases.UserCrud.CreateUser;
using Identity.Application.UseCases.UserCrud.DeleteUser;
using Identity.Application.UseCases.UserCrud.GetAllUsers;
using Identity.Application.UseCases.UserCrud.GetUserById;
using Identity.Presentation.Requests.UserRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class UsersController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly IMapper _mapper;

    public UsersController(IMediator mediator, IMapper mapper)
    {
        _mediator = mediator;
        _mapper = mapper;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] Requests.AuthenticationRequests.LogInRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<LogInUseCase>(request);

        var token = await _mediator.Send(useCase, cancellationToken);

        return token is not null ? Ok(token) : BadRequest();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] Requests.AuthenticationRequests.RegisterRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<RegisterUseCase>(request);

        var token = await _mediator.Send(useCase, cancellationToken);

        return token is not null ? Ok(token) : BadRequest();
    }

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<CreateUserUseCase>(request);

        var id = await _mediator.Send(useCase, cancellationToken);

        return id is not null ? Ok(id) : BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> DeleteUser(string id, CancellationToken cancellationToken)
    {
        await _mediator.Send(new DeleteUserUseCase { Id = id }, cancellationToken);

        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await _mediator.Send(new GetAllUsersUseCase(), cancellationToken);

        return users is not null ? Ok(users) : NotFound();
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetUserById(string id, CancellationToken cancellationToken)
    {
        var user = await _mediator.Send(new GetUserByIdUseCase { UserId = id}, cancellationToken);

        return user is not null ? Ok(user) : NotFound();
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> ChangeUserRole(string id, [FromBody] ChangeUserRoleRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<ChangeUserRoleUseCase>(request);
        useCase.UserId = id;

        var user = await _mediator.Send(useCase, cancellationToken);

        return user is not null ? Ok(user) : NotFound();
    }
}
