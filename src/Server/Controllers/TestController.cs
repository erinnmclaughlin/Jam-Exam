using Microsoft.AspNetCore.Mvc;
using Server.Authentication;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpGet, JamAuthorizationFilter]
        public IActionResult GetAuthorizedData()
        {
            return Ok("This is some data.");
        }
    }
}
