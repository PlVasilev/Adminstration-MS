namespace Administration.Server.Features
{
    using Microsoft.AspNetCore.Mvc;
    public class HomeController : ApiController
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Works");
        }

    }
}
