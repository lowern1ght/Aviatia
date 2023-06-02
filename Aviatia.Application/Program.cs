using Serilog;
using Serilog.Core;
using Serilog.Events;

namespace Aviatia.Application;

using StackExchange.Redis;

public static class Application
{
    private static void Main(string[] args)
    {
        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

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

        builder.Services.AddSwaggerGen();

        //Application
        WebApplication application = builder.Build();

        application.UseSession();
        
        application.UseRouting();
        
        application.UseCors(policyBuilder =>
        {
            policyBuilder.AllowAnyOrigin();
        });
        
        application.UseEndpoints(routeBuilder =>
        {
            routeBuilder.MapControllerRoute("default", "{controller=Home}/{action}/{id?}");
        });
        
        application.UseSwagger(options =>
        {
            options.RouteTemplate = "swagger/{document}/swagger.json";
        });

        application.UseSwaggerUI(options =>
        {
            options.SwaggerEndpoint("/swagger/v1/index.html", "aviatia/v1");
        });

        if (!application.Environment.IsDevelopment())
        {
            application.UseHttpsRedirection();
            
            application.UseHsts();
        }

        application.Run();
    }
}