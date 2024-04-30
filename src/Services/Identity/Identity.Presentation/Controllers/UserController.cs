using Identity.Application.Abstractions.Interfaces;
using Identity.Presentation.Model;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Presentation.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IAccountService _loginService;

        public UserController(IAccountService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        public async Task<IActionResult> LoginMember([FromBody] LoginRequest request, CancellationToken cancellationToken)
        {
            var token = _loginService.LoginAsync(request.Username, request.Password, request.Email);

            return token is not null ? Ok(token) : BadRequest();
        }
    }
}
