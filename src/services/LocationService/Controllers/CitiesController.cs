using Microsoft.AspNetCore.Mvc;

namespace LocationService.Controllers;

[ApiController]
[Route("/api/[controller]/[action]")]
public class CityController : Controller
{
    [HttpGet]
    [Route("/")]
    public Task<ActionResult<Object>> GetAllAsync([FromQuery] int skip = 0, [FromQuery] int take = 10)
    {
        throw new NotImplementedException();
    }
}