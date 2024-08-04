using angularCRUDAPI.Data;
using angularCRUDAPI.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace angularCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _dataContext;

        public EmployeeController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        [HttpGet]
        public async Task<ActionResult<List<Employee>>> GetAllEmployees()
        {
            var list = await _dataContext.Employees.ToListAsync();

            return Ok(list);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<List<Employee>>> GetEmployee(int id)
        {
            var employee = await _dataContext.Employees.FindAsync(id);
            if (employee is null)
                return NotFound("Employee not found");

            return Ok(employee);
        }
        [HttpPost]
         public async Task<ActionResult<List<Employee>>> AddEmployee(Employee employees)
         {
            _dataContext.Employees.Add(employees);
            await _dataContext.SaveChangesAsync();
            return await GetAllEmployees();
         }
        [HttpPut]
        public async Task<ActionResult<List<Employee>>> UpdateEmployee(Employee employees)
        {
            var emp = await _dataContext.Employees.FindAsync(employees.employeeId);
            if (emp is null)
                return NotFound("Employee not found");

            emp.employeeName = employees.employeeName;
            emp.employeeContactNumber = employees.employeeContactNumber;
            emp.employeeAddress = employees.employeeAddress;
            emp.employeeGender = employees.employeeGender;
            emp.employeeDepartment = employees.employeeDepartment;
            emp.employeeSkills = employees.employeeSkills;
            
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Employees.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Employee>>> DeleteEmployee(int id)
        {
            var emp = await _dataContext.Employees.FindAsync(id);
            if (emp is null)
                return NotFound("Employee not found");
            _dataContext.Employees.Remove(emp);
            await _dataContext.SaveChangesAsync();
            return Ok(await _dataContext.Employees.ToListAsync());
        }
    }
}
