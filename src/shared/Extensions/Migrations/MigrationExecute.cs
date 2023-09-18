using EFCore.AutomaticMigrations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

namespace Extensions.Migrations;

public static class MigrationExecute
{
    public static IServiceProvider RunMigrate<TDbContext>(this IServiceProvider serviceProvider)
        where TDbContext : DbContext
    {
        using var scope = serviceProvider.CreateScope();

        var context = scope.ServiceProvider.GetService<TDbContext>();
        if (context is null)
            throw new ArgumentNullException(nameof(context));

        var migrate = context.Database.GetService<IMigrate>();
        migrate.RunMigrations();
        
        return serviceProvider;
    }
}