using AuthorizationService.Database;
using Microsoft.EntityFrameworkCore;

namespace AuthorizationService.Migrations.Services;

public class MigrationService : IMigrationService
{
    private readonly ILogger<IMigrationService> _logger;
    private readonly AuthorizationDbContext _authorizationDbContext;

    public MigrationService(ILogger<IMigrationService> logger, 
        AuthorizationDbContext authorizationDbContext)
    {
        _logger = logger;
        _authorizationDbContext = authorizationDbContext;
    }
    
    public async Task ExecuteMigrateAsync()
    {
        try
        {
            await _authorizationDbContext.Database.MigrateAsync();
        }
        catch (Exception exception)
        {
            _logger.Log(LogLevel.Error, exception.Message);
        }
    }
}