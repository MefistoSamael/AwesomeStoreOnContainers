using Identity.Application.UseCases.RoleCrud.CreateRoleUseCase;
using Identity.Application.UseCases.RoleCrud.DeleteRoleUseCase;
using Identity.Application.UseCases.RoleCrud.GetAllRolesUseCase;
using MediatR;
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
        public async Task<IActionResult> CreateRole([FromBody] CreateRole request, CancellationToken cancellationToken)
        {
            var id = await _mediator.Send(request, cancellationToken);

            return Ok(id);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoles(CancellationToken cancellationToken)
        {
            var roles = await _mediator.Send(new GetAllRoles(), cancellationToken);
            return roles is not null ? Ok(roles) : NotFound();
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteRole(string id, CancellationToken cancellationToken)
        {
            await _mediator.Send(new DeleteRole { RoleId = id}, cancellationToken);

            return Ok();
        }
    }
}
