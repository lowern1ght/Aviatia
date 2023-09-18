using AutoMapper;
using Extensions.Configurations.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

namespace Extensions.Configurations;

public static class ConfigurationDbContext
{
    private static readonly IMapper Mapper;

    static ConfigurationDbContext()
    {
        Mapper = new MapperConfiguration(expression =>
        {
            expression.CreateMap<DbContextProperty, NpgsqlConnectionStringBuilder>();
        }).CreateMapper();
    }
    
    public static string? GetConnectionString<TDbContext>(this IConfiguration configuration, 
        IServiceProvider? serviceProvider = null)
        where TDbContext : DbContext
    {
        if (serviceProvider?.GetService<ConnectionString<TDbContext>>() is {Value: not null} connectionString)
        {
            return connectionString.Value;
        }

        var dbContextProperty = configuration.GetSection(nameof(TDbContext))
            .Get<DbContextProperty>() ?? throw new InvalidOperationException( nameof(DbContextProperty) + " failed parse");

        return Mapper.Map<NpgsqlConnectionStringBuilder>(dbContextProperty)
            .ConnectionString;
    }
}