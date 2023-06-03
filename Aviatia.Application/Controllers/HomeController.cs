using Aviatia.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Aviatia.Application.Controllers;

[Controller]
public class HomeController : Controller
{
    public IEmployeeRepository Repository { get; }

    public HomeController(IEmployeeRepository repository)
    {
        this.Repository = repository;

    }
    
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public async Task<IActionResult> GetEmployees()
    {
        return Ok();
    }
}