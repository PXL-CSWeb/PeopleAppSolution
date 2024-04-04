using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PeopleApp.Api.Services;
using PeopleApp.ClassLib.Models;

namespace PeopleApp.Api.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Department>>> ListDepartments()
        {
            var departments = await _departmentService.ListDepartmentsAsync();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Department>> GetDepartmentById(long id)
        {
            var department = await _departmentService.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost]
        public async Task<ActionResult<long>> AddDepartment([FromBody] Department department)
        {
            await _departmentService.AddDepartmentAsync(department);
            return Ok(department.Id);
        }

        [HttpPut]
        public async Task<ActionResult<Department>> UpdateDepartment([FromBody] Department department)
        {
            await _departmentService.UpdateDepartmentAsync(department);
            return Ok(department);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDepartment(long id)
        {
            await _departmentService.DeleteDepartmentAsync(id);
            return NoContent();
        }
    }
}
