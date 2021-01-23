using Microsoft.AspNetCore.Mvc;

namespace HacatonUntitledTeam.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hello Word";
        }
    }
}
