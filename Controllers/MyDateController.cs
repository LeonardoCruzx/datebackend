using Date.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace Date.Controllers;

[ApiController]
[Route("api/[controller]")]
[EnableCors("EnableCORS")]
public class MyDateController : ControllerBase
{
    private readonly DatabaseContext _context;

    public MyDateController(DatabaseContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(DateTime.Now);
    }

    [HttpPost("[action]")]
    public async Task<IActionResult> Create([FromBody] MyDateDTO myDateDTO)
    {
        var result = await _context.MyDates.AddAsync(myDateDTO.ToMyDate());
        await _context.SaveChangesAsync();
        return Ok();
    }
}
