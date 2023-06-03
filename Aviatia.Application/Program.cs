using Serilog;
using Serilog.Core;
using Aviatia.Data;
using Aviatia.Data.Interfaces;
using Aviatia.Data.Repository;
using Microsoft.Extensions.Configuration.CommandLine;
using Microsoft.OpenApi.Any;
using Microsoft.OpenApi.Interfaces;
using Microsoft.OpenApi.Models;
using Serilog.Events;

namespace Aviatia.Application;

public static class Application
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        if (ApplicationUtilities.NeedInitializationDb(builder.Configuration))
        {
            ApplicationUtilities.InitializationDbAviatia(builder.Configuration.GetConnectionString("Root"));
        }
        
        //DB Context
        builder.Services.AddSingleton<ApplicationContext>();
        
        builder.Services.AddScoped<IEmployeeRepository, EmployeeRepository>();
        
        builder.Services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        
        //Logging
        builder.Logging.ClearProviders();

        var logger = new LoggerConfiguration()
            .Enrich.FromLogContext()
            .MinimumLevel.ControlledBy(new LoggingLevelSwitch() { MinimumLevel = LogEventLevel.Debug})
            .WriteTo.Console()
            .CreateLogger();

        builder.Logging.AddSerilog(logger);
        
        //Services
        builder.Services.AddMvc();

        builder.Services.AddCors();

        builder.Services.AddControllers();
        
        builder.Services.AddDataProtection();

        builder.Services.AddDistributedMemoryCache();
        
        builder.Services.AddAntiforgery(options =>
        {
            options.Cookie.Name = "X_CRF_TOKEN";
        });
        
        builder.Services.AddSession(options =>
        {
            options.Cookie.Name = "aviatia_ssid";
            options.IdleTimeout = TimeSpan.FromHours(12);
        });
        
        builder.Services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost";
            options.InstanceName = "local";
        });

        builder.Services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo()
            {
                Version = "0.2a",
                Title = "Aviatia OpenAPI",
                Description = "Aviatia Service API",
                Contact = new OpenApiContact()
                {
                  Name = "Alexander Sergeev",
                  Email  = "lowern1ght@yahoo.com",
                  Url = new Uri(@"https://github.com/lowern1ght")
                },
                License = new OpenApiLicense()
                {
                    Name = "MIT License",
                }
            });
        });

        //Application
        WebApplication application = builder.Build();

        application.UseSession();

        if (!application.Environment.IsDevelopment())
        {
            application.UseHttpsRedirection();
            
            application.UseHsts();
        }
        else
        {
            application.UseDeveloperExceptionPage();
        }
        
        application.UseCors(policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin();
        });
        
        application.UseStaticFiles();
        
        application.UseRouting();
        
        application.UseSwagger();

        application.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/swagger.json", "aviatia/v1");
        });
        
        application.UseEndpoints(routeBuilder =>
        {
            routeBuilder.MapControllerRoute("default", "{controller=Home}/{action}/{id?}");
        });

        application.Run();
    }
}