using BankingAppWebApi.enums;
using BankingAppWebApi.Interfaces;
using BankingShared.Models;
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
            var authResponse = new AuthResponse();
            
            try
            {
                var result = _bankingDbRepository.PerformAuthenticationCheck(auth.UserName, auth.Pin);

                if (result)
                { 
                    var authentication = _bankingDbRepository.GetAuthentication(auth.UserName, auth.Pin);
                
                    if (authentication != null)
                    {
                        var customer = _bankingDbRepository.GetCustomerByAuthenticationId(authentication.AuthenticationId);

                        if (customer != null)
                        {
                            authResponse.Authenticated = true;
                            authResponse.AuthenticatedCustomer = customer;
                        }
                    }
                    
                }
                
                return Ok(authResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(SystemErrorCodes.AuthenticationFailed.ToString());
            }


        }

    }
}
