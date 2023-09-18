using AuthorizationService.Database;
using Extensions.Configurations;
using Extensions.Configurations.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile(builder.Environment.IsDevelopment()
    ? "dbcontexts.Development.json"
    : "dbcontexts.json");

var authorizationString = builder.Configuration.GetConnectionString<AuthorizationDbContext>();

builder.Services.AddSingleton(new ConnectionString<AuthorizationDbContext>(authorizationString));

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