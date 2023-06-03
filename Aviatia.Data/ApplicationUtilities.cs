using System.Globalization;
using System.Text;
using Dapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.CommandLine;
using Npgsql;

namespace Aviatia.Data;

public static class ApplicationUtilities
{
    public static Boolean NeedInitializationDb(ConfigurationManager configuration)
    {
        foreach (var source in configuration.Sources)
        {
            if (source is CommandLineConfigurationSource configurationSource)
            {
                foreach (var sourceArg in configurationSource.Args)
                {
                    if (sourceArg.Contains("--init"))
                    {
                        return true;
                    }
                }
            }
        }
        
        return false;
    }
    
    public static void InitializationDbAviatia(string? rootConnString)
    {
        if (rootConnString is null)
        {
            throw new ArgumentNullException(nameof(rootConnString), rootConnString);
        }
        
        
        
        using var connection = new NpgsqlConnection(rootConnString);

        connection.Open();

        String generatedPass = Convert.ToBase64String(
            Encoding.UTF8.GetBytes(new Random().NextDouble()
                .ToString(CultureInfo.InvariantCulture)));
        
        String queryCreateUser = $@"CREATE ROLE aviadmin WITH PASSWORD '{generatedPass}'";
        connection.Execute(queryCreateUser);

        String queryCreateDataBase = $@"CREATE DATABASE aviatia";



    }
}