using Serilog;
using Serilog.Core;
using Serilog.Events;
using Microsoft.Extensions.Logging;

namespace Extensions.Configurations;

public static class LoggerSerilog
{
    public static ILoggingBuilder AddDebugSerilog(this ILoggingBuilder loggingBuilder)
    {
        return AddConsoleSerilog(loggingBuilder, LogEventLevel.Debug);
    }

    public static ILoggingBuilder AddWarningSerilog(this ILoggingBuilder loggingBuilder)
    {
        return AddConsoleSerilog(loggingBuilder, LogEventLevel.Warning);
    }
    
    public static ILoggingBuilder AddConsoleSerilog(this ILoggingBuilder loggingBuilder, LogEventLevel eventLevel, 
        bool needClearProviders = true)
    {
        if (needClearProviders)
        {
            loggingBuilder.ClearProviders();
        }
        
        return loggingBuilder.AddSerilog(CreateLogger(eventLevel));
    }

    private static Logger CreateLogger(LogEventLevel eventLevel = LogEventLevel.Information)
    {
        return new LoggerConfiguration()
            .MinimumLevel.Is(eventLevel)
            .WriteTo.Console()
            .CreateLogger();
    }
}