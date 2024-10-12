using Microsoft.AspNetCore.Mvc;

namespace MonitoringService.Controllers;

[ApiController]
[Route("[controller]")]
public class TestController : ControllerBase
{
    [HttpGet(Name = "test")]
    public IActionResult Get()
    {
        return Ok(true);
    }
}