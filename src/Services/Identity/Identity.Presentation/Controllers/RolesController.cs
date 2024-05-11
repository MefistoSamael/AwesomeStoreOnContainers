using Identity.Application.UseCases.RoleCrud.CreateRoleUseCase;
using Identity.Application.UseCases.RoleCrud.DeleteRoleUseCase;
using Identity.Application.UseCases.RoleCrud.GetAllRolesUseCase;
using Identity.Application.UseCases.RoleCrud.UpdateRoleUseCase;
using Identity.Presentation.Requests.RoleRequests;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RolesController : ControllerBase
    {
        private readonly IMediator _mediator;
        
        public RolesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(new CreateRole
            {
                Name = request.Name,
            }, cancellationToken);

            return Ok(id);
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
        {
            var roles = await _mediator.Send(new GetAllRoles(), cancellationToken);
            return roles is not null ? Ok(roles) : NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteRole(string id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRole { RoleId = id}, cancellationToken);

            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateRole(string id, [FromBody] UpdateRoleRequest request, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateRole { RoleId = id, NewRoleName = request.NewRoleName }, cancellationToken);

            return Ok(result);
        }
    }
}
