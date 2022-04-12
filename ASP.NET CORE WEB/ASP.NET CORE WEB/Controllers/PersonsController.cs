using ASP.NET_CORE_WEB.Models;
using ASP.NET_CORE_WEB.Repository;
using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_CORE_WEB.Controllers
{
    [ApiController]
    [Route("api")]
    public class PersonsController : ControllerBase
    {
        [HttpGet("persons /{id})")]
        public async Task<ActionResult<PersonModel>> GetById ([FromRoute] int id)
        {            
            return Ok();
        }

        [HttpGet("persons/search")]
        public async Task<IEnumerable<PersonModel>> FindByName ([FromQuery] string SearchName,
            [FromQuery] int skip = 1,
            [FromQuery] int take = 50)
        {          
            return (IEnumerable<PersonModel>)Ok();
        }

        [HttpGet("persons/search/all")]
        public async Task<IEnumerable<PersonModel>> FindAll([FromQuery] int skip = 1,[FromQuery] int take = 50)
        {           
            return (IEnumerable<PersonModel>)Ok();
        }

        [HttpPost("persons/add")]
        public async Task<ActionResult<PersonModel>> AddAsync([FromBody] PersonModel person)
        {            
            return Ok();
        }

        [HttpPut("persons/update")]
        public async Task<IActionResult> UpdateAsync([FromBody] PersonModel person)
        {          
            return Ok();
        }

        [HttpDelete("persons/delete")]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {           
            return Ok();
        }
    }
}