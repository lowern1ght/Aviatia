using Microsoft.EntityFrameworkCore;

namespace Extensions.Configurations.Models;

public class ConnectionString<TDbContext> where TDbContext : DbContext
{
    public string? Value { get; init; }

    public override string? ToString()
    {
        return Value?.ToString();
    }

    public ConnectionString(string? value)
    {
        Value = value;
    }
}