using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Aviatia.Application.Controllers;

[Controller]
[Route("/")]
public class AccountController : Controller
{
    [HttpGet]
    [Route("/logout")]
    public IActionResult Login()
    {
        return Ok();
    }

    [HttpGet]
    [Authorize]
    [Route("/logout")]
    public IActionResult Logout()
    {
        return Ok();
    }
}