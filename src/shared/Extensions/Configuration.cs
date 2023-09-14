using Serilog;
using Serilog.Core;
using Serilog.Events;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions;

public static class Configuration
{
    public static IServiceCollection AddDebugSerilog(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSerilog(CreateLogger(LogEventLevel.Debug));
    }
    
    public static IServiceCollection AddWarningSerilog(this IServiceCollection serviceCollection)
    {
        return serviceCollection
            .AddSerilog(CreateLogger(LogEventLevel.Warning));
    }

    private static Logger CreateLogger(LogEventLevel eventLevel = LogEventLevel.Information)
    {
        return new LoggerConfiguration()
            .MinimumLevel.Is(eventLevel)
            .WriteTo.Console()
            .CreateLogger();
    }
}