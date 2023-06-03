using Aviatia.Data.Entities;
using Aviatia.Data.Extentions;
using Aviatia.Data.Interfaces;
using Dapper;

namespace Aviatia.Data.Repository;

public class EmployeeRepository : IEmployeeRepository
{
    public ApplicationContext Context { get; init; }

    public EmployeeRepository(ApplicationContext context)
    {
        this.Context = context;
    }

    public Task<Employee> GetEmployeeAsync(Guid id)
    {
        String query = $@"
            SELECT * 
            FROM {nameof(Employee).ToSnakeCase()}
            WHERE {nameof(Employee).ToSnakeCase()}.id";

        using var conn = this.Context.CreateConnection();

        return conn.QueryFirstAsync<Employee>(query, new { id });
    }

    public Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
        String query = $@"
            SELECT * 
            FROM {nameof(Employee).ToSnakeCase()}";

        using var conn = this.Context.CreateConnection();

        return conn.QueryAsync<Employee>(query);
    }
}