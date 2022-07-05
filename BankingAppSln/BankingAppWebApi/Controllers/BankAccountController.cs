using BankingAppWebApi.enums;
using BankingAppWebApi.Interfaces;
using BankingAppWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankAccountController : ControllerBase
    {
        private readonly IBankingDbRepository _bankingDbRepository;

        public BankAccountController(IBankingDbRepository bankingDbRepository)
        {
            _bankingDbRepository = bankingDbRepository;
        }

        [HttpPost]
        public IActionResult CreateBankAccount([FromBody] BankAccount bankAccount)
        {
            try
            {
                if (bankAccount == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.BankAccountNotValid.ToString());
                }
                _bankingDbRepository.CreateNewBankAccount(bankAccount);
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.BankAccountCreationFailed.ToString());
            }
            return Ok(bankAccount);
        }


        [HttpGet("bycustomerid")]
        public IList<BankAccount> Get([FromQuery] int customerId)
        {
            return _bankingDbRepository.GetBankAccountsByCustomerId(customerId);
        }
    }
}
