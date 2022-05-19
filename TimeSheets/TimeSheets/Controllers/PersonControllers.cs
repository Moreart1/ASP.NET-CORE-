using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation;
using TimeSheets.DAL.Validation.PersonValidation;
using TimeSheets.DAL.Validation.Services;

namespace TimeSheets.Controllers
{
    [Authorize]
    [Route("person/[controller]")]
    [ApiController]
    public class PersonControllers : ControllerBase
    {
        public readonly PersonRepository personRepository;
        private ICreatePersonValidator personValidator;
        private IDeletePersonValidator deleteValidator;

        public PersonControllers(PersonRepository personRepository,ICreatePersonValidator personValidator,IDeletePersonValidator deleteValidator)
        {
            this.personRepository = personRepository;
            this.personValidator = personValidator;
            this.deleteValidator = deleteValidator;

        }

        [HttpGet]
        public async Task<ActionResult<Person>> GetAll()
        {
            var result = await personRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<Person>> Create ([FromBody] Person newPerson)
        {
            var request = new Person
            {
                FirstName = newPerson.FirstName,
                LastName = newPerson.LastName,
                Email = newPerson.Email,
                Age = newPerson.Age,
                Id = newPerson.Id,
                Company = newPerson.Company,
                IsDelete = newPerson.IsDelete
            };
            var validation = new OperationResult<Person>(personValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            await personRepository.Add(newPerson);
            return NoContent();
        }

        [HttpPut]
        public async  Task<ActionResult<Person>> Update ([FromBody] Person newPerson)
        {
            await personRepository.Update(newPerson);
            return NoContent();
        }

        [HttpDelete("Delete")]
        public async Task<ActionResult<Person>> Delete(int Id)
        {
            var request = new PersonDeleteModels { Id = Id };
            var validation = new OperationResult<PersonDeleteModels>(deleteValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            await personRepository.Delete(request);
            return NoContent();
        }
    }
}
