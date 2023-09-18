using System.Globalization;
using AuthorizationService.Database;
using Extensions.Configurations;
using Extensions.Configurations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders()
    .AddSerilog();

builder.Configuration.AddJsonFile(builder.Environment.IsDevelopment()
    ? "dbcontext.Development.json"
    : "dbcontext.json");

var authorizationString = builder.Configuration.GetConnectionString<AuthorizationDbContext>();

builder.Services.AddSingleton(new ConnectionString<AuthorizationDbContext>(authorizationString));

builder.Services.AddDbContext<AuthorizationDbContext>(optionsBuilder 
    => optionsBuilder.UseSnakeCaseNamingConvention(CultureInfo.InvariantCulture)
        .UseNpgsql(authorizationString));

builder.Services
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "av.ck";
    });

builder.Services.AddIdentity<IdentityUser, IdentityRole>()
    .AddEntityFrameworkStores<AuthorizationDbContext>();

builder.Services.AddAntiforgery(options 
    => options.Cookie.Name = "av.af" );

builder.Services.AddControllers();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer()
        .AddSwaggerGen();
}

var application = builder.Build();

if (application.Environment.IsDevelopment())
{
    application.UseSwagger();
    application.UseSwaggerUI();
}

application.UseAuthorization();

application.MapControllers();

application.Run();