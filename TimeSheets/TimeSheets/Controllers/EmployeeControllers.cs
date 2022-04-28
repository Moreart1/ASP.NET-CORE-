using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.EmployeeValidation;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.Controllers
{
    [Authorize]
    [Route("employee/[controller]")]
    [ApiController]
    public class EmployeeControllers : ControllerBase
    {
        public readonly EmployeeRepository employeeRepository;
        private ICreateEmployeeValidator createEmployeeValidator;
        private IDeleteEmployeeValidator deleteEmployeeValidator;

        public EmployeeControllers(EmployeeRepository employeeRepository,
            ICreateEmployeeValidator createEmployeeValidator,
            IDeleteEmployeeValidator deleteEmployeeValidator)
        {
            this.employeeRepository = employeeRepository;
            this.createEmployeeValidator = createEmployeeValidator;
            this.deleteEmployeeValidator = deleteEmployeeValidator;
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
            var request = new Employee
            {
                FirstName = newEmployee.FirstName,
                LastName = newEmployee.LastName,
                Email = newEmployee.Email,
                Age = newEmployee.Age,
                Id = newEmployee.Id,
                Company = newEmployee.Company,
                IsDelete = newEmployee.IsDelete
            };
            var validation = new OperationResult<Employee>(createEmployeeValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
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
            var request = new EmployeeDeleteModel { Id = Id };
            var validation = new OperationResult<EmployeeDeleteModel>(deleteEmployeeValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }           
            await employeeRepository.Delete(request);
            return NoContent();
        }
    }
}
