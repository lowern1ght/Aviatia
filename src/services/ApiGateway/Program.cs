using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;

string ocelotFileName = "ocelot.json";

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOcelot()
    .AddCacheManager(part => part.WithDictionaryHandle());

builder.Configuration.AddJsonFile(ocelotFileName)
    .AddEnvironmentVariables();

var application = builder.Build();

await application.UseOcelot()
    .WaitAsync(TimeSpan.Zero);

application.MapGet("/", () => $"{application.Configuration.GetValue<string>("ApplicationName") ?? "Aviatia"} " +
                              $"is working");
application.Run();