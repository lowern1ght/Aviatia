using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Validations.Rules;

namespace AuthorizationService.Controllers.Api;

[Authorize]
[OpenApiRule]
[ApiController]
[Route("api/[controller]")]
public class TokenController : Controller
{
    
}