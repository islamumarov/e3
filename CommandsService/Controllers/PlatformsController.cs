using Microsoft.AspNetCore.Mvc;
namespace CommandsService.Controllers
{
    [ApiController]
    [Route("api/c/[controller]")]
    public class PlatformsController : ControllerBase
    {
        public PlatformsController()
        {
            
        }
        [HttpPost]
        public ActionResult TestInboundedConnection()
        {
            Console.WriteLine("------> Inbounded Connection");
            
            return Ok("Inbounded test of from Platform Controller");
        }
    }
}