using AuthorizationService.Database;
using Microsoft.AspNetCore.Mvc;

namespace AuthorizationService.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class EmployeesController : Controller
{
    private readonly ILogger<EmployeesController> _logger;
    private readonly AuthorizationDbContext _authorizationDbContext;

    public EmployeesController(ILogger<EmployeesController> logger, 
        AuthorizationDbContext authorizationDbContext)
    {
        _logger = logger;
        _authorizationDbContext = authorizationDbContext;
    }
    
    [HttpGet]
    public Task<ActionResult> GetAsync()
    {
        return Task.FromResult<ActionResult>(Ok(_authorizationDbContext.Database.ProviderName));
    }
}