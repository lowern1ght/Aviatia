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
        
        var sectionName = typeof(TDbContext).FullName?
            .Split('.')
            .Last();

        if (sectionName is null)
            throw new ArgumentNullException(nameof(sectionName));
        
        var dbContextProperty = configuration.GetSection(sectionName)
            .Get<DbContextProperty>() ?? throw new InvalidOperationException( nameof(DbContextProperty) + " failed parse");

        return Mapper.Map<NpgsqlConnectionStringBuilder>(dbContextProperty)
            .ConnectionString;
    }
}