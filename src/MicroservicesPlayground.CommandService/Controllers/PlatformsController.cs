using Microsoft.AspNetCore.Mvc;

namespace MicroservicesPlayground.CommandService.Controllers;

[ApiController, Route("api/c/[controller]")]
public class PlatformsController : ControllerBase
{
    public PlatformsController()
    {
        
    }

    [HttpPost]
    public ActionResult TestInboundConnection()
    {
        Console.WriteLine("--> Inbound POST # Commands service");

        return Ok("Inbound test of from Platforms controller");
    }
}
