using Aviatia.Data.Entities;

namespace Aviatia.Data.Interfaces;

public interface IEmployeeRepository
{
    public Task<Employee> GetEmployeeAsync(Guid id);

    public Task<IEnumerable<Employee>> GetEmployeesAsync();
}