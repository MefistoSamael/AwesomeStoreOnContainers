using Identity.Application.UseCases.RoleCrud.GetPaginatedRoles;
using Identity.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : ControllerBase
{
    private readonly IMediator _mediator;

    public RolesController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Authorize(Roles = RoleConstants.Admin)]
    public async Task<IActionResult> GetPaginatedRoles([FromQuery] int pageNumber = 1, [FromQuery] int pageSize = 3, CancellationToken cancellationToken = default)
    {
        var request = new GetPaginatedRolesUseCase { PageNumber = pageNumber, PageSize = pageSize };

        var roles = await _mediator.Send(request, cancellationToken);

        return Ok(roles);
    }
}
