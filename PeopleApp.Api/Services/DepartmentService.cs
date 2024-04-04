using Microsoft.EntityFrameworkCore;
using PeopleApp.Api.Data;
using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly DataContext _context;

        public DepartmentService(DataContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Department>> ListDepartmentsAsync()
        {
            return await _context.Departments.Include(d => d.People).ToListAsync();
        }

        public async Task<Department> GetDepartmentById(long id)
        {
            return await _context.Departments.Include(d => d.People).FirstOrDefaultAsync(d => d.Id == id);
        }

        public async Task<Department> AddDepartmentAsync(Department department)
        {
            _context.Departments.Add(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task<Department> UpdateDepartmentAsync(Department department)
        {
            _context.Departments.Update(department);
            await _context.SaveChangesAsync();
            return department;
        }

        public async Task DeleteDepartmentAsync(long id)
        {
            var department = await _context.Departments.FindAsync(id);
            if (department is null)
                return;
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
