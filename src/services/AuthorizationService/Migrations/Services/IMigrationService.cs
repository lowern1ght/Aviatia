using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Migrations.Services;

public interface IMigrationService
{
    Task ExecuteMigrateAsync();
}