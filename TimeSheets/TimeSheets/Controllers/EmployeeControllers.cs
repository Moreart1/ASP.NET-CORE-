using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("employee/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        public readonly EmployeeRepository employeeRepository;

        public EmployeeControllers(EmployeeRepository employeeRepository)
        {
            this.employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<ActionResult<Employee>> GetAll()
        {
            var result = await employeeRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create([FromBody] Employee newEmployee)
        {
            await employeeRepository.Add(newEmployee);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<Employee>> Update([FromBody] Employee newEmployee)
        {
            await employeeRepository.Update(newEmployee);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<Employee>> Delete(int Id)
        {
            await employeeRepository.Delete(Id);
            return NoContent();
        }
    }
}
