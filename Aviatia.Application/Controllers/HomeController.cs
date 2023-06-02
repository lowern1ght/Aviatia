using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;

namespace Aviatia.Application.Controllers;

[Controller]
[Route("/")]
public class HomeController : Controller
{
    public ILogger<HomeController> Logger { get; }
    public IDistributedCache DistributedCache { get; }

    public HomeController(IDistributedCache distributedCache, ILogger<HomeController> logger)
    {
        this.DistributedCache = distributedCache;
        this.Logger = logger;

    }
    
    [HttpGet]
    [Route("/")]
    public IActionResult Index()
    {
        return Ok(JsonSerializer.Serialize(User));
    }
}