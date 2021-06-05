namespace Administration.Server.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Authorization;

    public class HomeController : ApiController
    {
        [Authorize]
        public IActionResult Get()
        {
            return Ok("Works");
        }

    }
}
