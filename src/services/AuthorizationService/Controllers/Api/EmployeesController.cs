using System.Net;
using System.Text.Json;
using AuthorizationService.AuthorizationConstants;
using AuthorizationService.Database;
using AuthorizationService.Models.Authorization;
using AuthorizationService.Models.Identity;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Validations.Rules;

namespace AuthorizationService.Controllers.Api;

[Authorize]
[OpenApiRule]
[ApiController]
[Route("api/[controller]/[action]")]
public class EmployeesController : Controller
{
    private readonly RoleManager<Employee> _roleManager;
    private readonly AbstractValidator<UserDto> _validator;
    private readonly SignInManager<Employee> _signInManager;

    private readonly ILogger<EmployeesController> _logger;
    private readonly AuthorizationDbContext _authorizationDbContext;

    public EmployeesController(ILogger<EmployeesController> logger,
        AuthorizationDbContext authorizationDbContext, SignInManager<Employee> signInManager,
        RoleManager<Employee> roleManager, AbstractValidator<UserDto> validator)
    {
        _logger = logger;
        _roleManager = roleManager;
        _validator = validator;
        _signInManager = signInManager;
        _authorizationDbContext = authorizationDbContext;
    }

    [HttpGet]
    [Authorize(Roles = nameof(Roles.Admin))]
    public Task<ActionResult> IndexAsync()
    {
        return Task.FromResult<ActionResult>(Ok(_authorizationDbContext.Users.ToList()));
    }

    [HttpPost]
    [AllowAnonymous]
    [ActionName("register")]
    public async Task<ActionResult<Result>> RegisterEmployeeAsync([FromBody] UserDto userDto)
    {
        var validate = await _validator.ValidateAsync(userDto);
        if (validate.IsValid)
        {
            return new ActionResult<Result>(new Result()
            {
                Status = ResultStatus.Error,
                DescriptionMessage = String.Concat(validate.Errors, ", ")
            });
        }

        return new ActionResult<Result>(new Result());
    }
}