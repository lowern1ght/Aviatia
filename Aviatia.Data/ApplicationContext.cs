using System.Data;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Npgsql;

namespace Aviatia.Data;

public class ApplicationContext
{
    private String ConnectionString { get; init; }
 
    private IConfiguration Configuration { get; set; }
    
    public ApplicationContext(IConfiguration configuration)
    {
        this.Configuration = configuration;
        var connString = Configuration.GetConnectionString("Default");

        if (connString != null)
        {
            ConnectionString = configuration.GetConnectionString("Default")!;
        }
        else
        {
            throw new ArgumentNullException(nameof(ConnectionString), "connection string 'Default' is null");
        }
    }

    public IDbConnection CreateConnection()
        => new NpgsqlConnection(ConnectionString);
}