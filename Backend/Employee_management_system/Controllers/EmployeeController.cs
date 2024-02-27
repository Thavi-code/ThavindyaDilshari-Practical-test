using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Employee_management_system.Data;
using Employee_management_system.Models;
using Microsoft.Extensions.Configuration;


namespace Employee_management_system.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeeController : ControllerBase
    {

        private readonly AppDbContext _context;
        private readonly IConfiguration _configuration; 


        public EmployeeController(AppDbContext context, IConfiguration configuration) 
        {
            _context = context;
            _configuration = configuration;
        }

        // Get all employees
        [HttpGet]
        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            
            return await _context.Employees.Include(e => e.Departments).ToListAsync();
        }

        // Get an employee by ID
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
           
            var employee = await _context.Employees.Include(e => e.Departments).FirstOrDefaultAsync(e => e.EmployeeId == id);

            if (employee == null)
            {
                return NotFound();
            }

            return employee;
        }

        // Add a new employee
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

           
            await _context.Employees.AddRangeAsync(employee);
            
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
        }

        // Update an existing employee
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEmployee(int id, Employee employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            _context.Entry(employee).State = EntityState.Modified;
        
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // Delete an existing employee
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FindAsync(id);

            if (employee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employee);
            
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
