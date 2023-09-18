using AuthorizationService.Database;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;

namespace AuthorizationService.Controllers.Api;

[Authorize]
[OpenApiRule]
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
        return Task.FromResult<ActionResult>(Ok(_authorizationDbContext.Users));
    }
}