using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheets.BL.Repositories;
using TimeSheets.DAL.Models;

namespace TimeSheets.Controllers
{
    [Route("bankAccount/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        public readonly BankAccountRepository repository;

        public BankAccountController(BankAccountRepository repository)
        {
            this.repository = repository;
        }

        [HttpPost]
        public async Task<ActionResult<BankAccount>> Create()
        {
            await repository.Add();
            return NoContent();
        }

        [HttpGet]
        public async Task<ActionResult<BankAccount>> Get()
        {
            var getAll = await repository.Get();
            return Ok(getAll);
        }

        [HttpPut]
        public async Task<ActionResult<BankAccount>> Operation([FromBody]BankAccount bankAccount)
        {
            await repository.Operation(bankAccount);
            return NoContent();
        }
        [HttpDelete]
        public async Task<ActionResult<BankAccount>> Delete([FromBody] BankAccount bankAccount)
        {
            await repository.Close(bankAccount);
            return NoContent();
        }
    }
}
