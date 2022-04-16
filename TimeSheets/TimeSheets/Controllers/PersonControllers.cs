using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("person/[controller]")]
    [ApiController]
    public class PersonControllers : ControllerBase
    {
        public readonly PersonRepository personRepository;
        public PersonControllers(PersonRepository personRepository)
        {
            this.personRepository = personRepository;
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
            await personRepository.Delete(Id);
            return NoContent();
        }
    }
}
