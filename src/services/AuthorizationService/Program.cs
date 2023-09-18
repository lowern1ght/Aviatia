using System.Globalization;
using AuthorizationService.Database;
using AuthorizationService.Migrations.Services;
using AuthorizationService.Models.Authorization;
using AuthorizationService.Models.Identity;
using AuthorizationService.Validation;
using Extensions.Configurations;
using Extensions.Configurations.Models;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog.Events;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsoleSerilog(builder.Environment.IsDevelopment() 
    ? LogEventLevel.Debug 
    : LogEventLevel.Warning);

builder.Configuration.AddJsonFile(builder.Environment.IsDevelopment()
    ? "dbcontext.Development.json"
    : "dbcontext.json");

var authorizationString = builder.Configuration.GetConnectionString<AuthorizationDbContext>();

builder.Services.AddSingleton(new ConnectionString<AuthorizationDbContext>(authorizationString));

//Migration
builder.Services.AddScoped<IMigrationService, MigrationService>();

//Identity with DbContext
builder.Services.AddDbContext<AuthorizationDbContext>(optionsBuilder
    => optionsBuilder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
        .UseNpgsql(authorizationString)
        .UseOpenIddict());

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "av.ck";
    });

builder.Services
    .AddIdentity<Employee, IdentityRole>()
    .AddEntityFrameworkStores<AuthorizationDbContext>();

builder.Services.AddOpenIddict()
    .AddServer(serverBuilder =>
    {
        serverBuilder.SetTokenEndpointUris("api/token");
    });

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Lockout.AllowedForNewUsers = true;
    options.Lockout.MaxFailedAccessAttempts = 4;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
});

//Other services
builder.Services.AddRouting(options 
        => options.LowercaseUrls = true)
    .AddControllers();

builder.Services.AddAntiforgery(options 
    => options.Cookie.Name = "av.af" );

builder.Services.AddControllers();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer()
        .AddSwaggerGen();
}

//Validators
builder.Services.AddScoped<AbstractValidator<UserDto>, UserDtoValidator>();

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseRouting();

application.UseAuthentication();
application.UseAuthorization();

application.MapControllers();

application.Run();