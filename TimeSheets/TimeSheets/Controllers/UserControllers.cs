using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;
using TimeSheets.DAL.Validation.Services;
using TimeSheets.DAL.Validation.UserValidation;

namespace TimeSheets.Controllers
{
    [Authorize]
    [Route("user/[controller]")]
    [ApiController]
    public class UserControllers : ControllerBase
    {
        public readonly UserRepository userRepository;
        private ICreateUserValidator createUserValidator;
        private IDeleteUserValidator deleteUserValidator;

        public UserControllers(UserRepository userRepository,
            ICreateUserValidator createUserValidator,
            IDeleteUserValidator deleteUserValidator)
        {
            this.userRepository = userRepository;
            this.createUserValidator = createUserValidator;
            this.deleteUserValidator = deleteUserValidator;
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
            var request = new User
            {
                FirstName = newUser.FirstName,
                LastName = newUser.LastName,
                Email = newUser.Email,
                Age = newUser.Age,
                Id = newUser.Id,
                Company = newUser.Company,
                IsDelete = newUser.IsDelete
            };
            var validation = new OperationResult<User>(createUserValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
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
            var request = new UserDeleteModel { Id = Id };
            var validation = new OperationResult<UserDeleteModel>(deleteUserValidator.ValidateEntity(request));
            if (!validation.Succeed)
            {
                return BadRequest(validation);
            }
            await userRepository.Delete(request);
            return NoContent();
        }
    }
}
