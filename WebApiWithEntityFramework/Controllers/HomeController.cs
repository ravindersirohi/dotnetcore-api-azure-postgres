using Microsoft.AspNetCore.Mvc;

namespace WebApiWithEntityFramework.Controllers
{
    [Route("")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Welcome to Web API with Entity Framework (Core) and Postgres database !!";
        }
    }
}
