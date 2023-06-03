using Aviatia.Data.Entities;

namespace Aviatia.Data.Interfaces;

public interface IDepartmentRepository
{
    public Department GetDepartment(Int32 id);
    
    public Task<Department> GetDepartmentAsync(Int32 id);

    public IEnumerable<Department> GetDepartments();
    
    public Task<IEnumerable<Department>> GetDepartmentsAsync();

}