using Microsoft.AspNetCore.Mvc;

namespace Date.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DateController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(DateTime.Now);
    }
}
