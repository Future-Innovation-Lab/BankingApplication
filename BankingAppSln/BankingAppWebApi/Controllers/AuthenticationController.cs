using BankingAppWebApi.enums;
using BankingAppWebApi.Interfaces;
using BankingAppWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IBankingDbRepository _bankingDbRepository;

        public AuthenticationController(IBankingDbRepository bankingDbRepository)
        {
            _bankingDbRepository = bankingDbRepository;
        }


        [HttpPost]
        public IActionResult Post([FromBody] AuthRequest auth)
        {
            try
            {
                var result = _bankingDbRepository.PerformAuthenticationCheck(auth.UserName, auth.Pin);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.AuthenticationFailed.ToString());
            }


        }

    }
}
