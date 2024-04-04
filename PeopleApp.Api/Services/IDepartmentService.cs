using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Services
{
    public interface IDepartmentService
    {
        Task<Department> AddDepartmentAsync(Department department);
        Task DeleteDepartmentAsync(long id);
        Task<Department> GetDepartmentById(long id);
        Task<IEnumerable<Department>> ListDepartmentsAsync();
        Task<Department> UpdateDepartmentAsync(Department department);
    }
}