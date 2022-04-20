using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("user/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        public readonly UserRepository userRepository;
        public UserControllers(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<User>> GetAll()
        {
            var result = await userRepository.Get();
            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<User>> Create([FromBody] User newUser)
        {
            await userRepository.Add(newUser);
            return NoContent();
        }

        [HttpPut]
        public async Task<ActionResult<User>> Update([FromBody] User newUser)
        {
            await userRepository.Update(newUser);
            return NoContent();
        }

        [HttpDelete]
        public async Task<ActionResult<User>> Delete(int Id)
        {
            await userRepository.Delete(Id);
            return NoContent();
        }
    }
}
