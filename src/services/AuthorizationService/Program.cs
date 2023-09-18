using AuthorizationService.Database;
using Extensions.Configurations;
using Extensions.Configurations.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.Cookie.Name = "av.ck";
    });

builder.Configuration.AddJsonFile("dbcontexts.json");

var authorizationString = builder.Configuration.GetConnectionString<AuthorizationDbContext>();

builder.Services.AddSingleton(new ConnectionString<AuthorizationDbContext>(authorizationString));

builder.Services.AddAntiforgery(options 
    => options.Cookie.Name = "av.af" );

builder.Services.AddControllers();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddEndpointsApiExplorer()
        .AddSwaggerGen();
}

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();