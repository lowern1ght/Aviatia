using Aviatia.Data.Entities;
using Aviatia.Data.Extentions;
using Aviatia.Data.Interfaces;
using Dapper;

namespace Aviatia.Data.Repository;

public class DepartmentRepository : IDepartmentRepository
{
    public ApplicationContext Context { get; init; }

    public DepartmentRepository(ApplicationContext context)
    {
        Context = context;
    }

    public Department GetDepartment(int id)
    {
        String query = $@"
            SELECT * 
            FROM {nameof(Department).ToSnakeCase()} 
            WHERE {nameof(Department).ToSnakeCase()}.id = @id";

        using var conn = Context.CreateConnection();

        return conn.QueryFirst<Department>(query, new { id });
    }

    public Task<Department> GetDepartmentAsync(int id)
    {
        String query = $@"
            SELECT * 
            FROM {nameof(Department).ToSnakeCase()} 
            WHERE {nameof(Department).ToSnakeCase()}.id = @id";

        using var conn = Context.CreateConnection();

        return conn.QueryFirstAsync<Department>(query, new { id });
    }

    public IEnumerable<Department> GetDepartments()
    {
        String query = $@"
            SELECT * 
            FROM { nameof(Department).ToSnakeCase() }";
        
        using var conn = Context.CreateConnection();

        return conn.Query<Department>(query);
    }

    public Task<IEnumerable<Department>> GetDepartmentsAsync()
    {
        String query = $@"
            SELECT * 
            FROM { nameof(Department).ToSnakeCase() }";
        
        using var conn = Context.CreateConnection();

        return conn.QueryAsync<Department>(query);
    }
}