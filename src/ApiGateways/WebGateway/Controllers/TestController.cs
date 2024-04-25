using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebGateway.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class TestController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        

        public TestController()
        {
        }

        [HttpGet]
        [Route("NotAuthorized")]
        public IActionResult GetNotAuthorized()
        {
            return Ok("authorized");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        [Route("Admin")]
        public IActionResult GetAdmin()
        {
            return Ok("admin");
        }
    }
}
