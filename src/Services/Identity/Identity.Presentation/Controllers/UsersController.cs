using AutoMapper;
using Identity.Application.UseCases.Authentication.LogIn;
using Identity.Application.UseCases.Authentication.Refresh;
using Identity.Application.UseCases.Authentication.Register;
using Identity.Application.UseCases.UserCrud.ChangeRole;
using Identity.Application.UseCases.UserCrud.CreateUser;
using Identity.Application.UseCases.UserCrud.DeleteUser;
using Identity.Application.UseCases.UserCrud.GetPaginatedUsers;
using Identity.Application.UseCases.UserCrud.GetUserById;
using Identity.Domain.Entities;
using Identity.Presentation.Requests.AuthenticationRequests;
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
    [Route("refresh")]
    public async Task<IActionResult> Refresh([FromBody] RefreshRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<RefreshUseCase>(request);

        var token = await _mediator.Send(useCase, cancellationToken);

        return Ok(token);
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
    [Authorize(Roles = RoleConstants.Admin)]
    public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<CreateUserUseCase>(request);

        var id = await _mediator.Send(useCase, cancellationToken);

        return id is not null ? Ok(id) : BadRequest();
    }

    [HttpDelete]
    [Route("{id}")]
    [Authorize(Roles = RoleConstants.Admin)]
    public async Task<IActionResult> DeleteUser([FromQuery] string id, CancellationToken cancellationToken)
    {
        var request = new DeleteUserUseCase { Id = id };

        await _mediator.Send(request, cancellationToken);

        return Ok();
    }

    [HttpGet]
    [Authorize(Roles = RoleConstants.Admin)]
    public async Task<IActionResult> GetPaginatedUsers(CancellationToken cancellationToken, [FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3)
    {
        var request = new GetPaginatedUsersUseCase { PageNumber = pageNumber, PageSize = pageSize };
        var users = await _mediator.Send(request, cancellationToken);

        return Ok(users);
    }

    [HttpGet]
    [Route("{id}")]
    [Authorize(Roles = RoleConstants.Admin)]
    public async Task<IActionResult> GetUserById([FromQuery] string id, CancellationToken cancellationToken)
    {
        var request = new GetUserByIdUseCase { UserId = id };

        var user = await _mediator.Send(request, cancellationToken);

        return Ok(user);
    }

    [HttpPut]
    [Route("{id}")]
    [Authorize(Roles = RoleConstants.Admin)]
    public async Task<IActionResult> ChangeUserRole([FromQuery] string id, [FromBody] ChangeUserRoleRequest request, CancellationToken cancellationToken)
    {
        var useCase = _mapper.Map<ChangeUserRoleUseCase>(request);
        useCase.UserId = id;

        var user = await _mediator.Send(useCase, cancellationToken);

        return user is not null ? Ok(user) : NotFound();
    }
}
