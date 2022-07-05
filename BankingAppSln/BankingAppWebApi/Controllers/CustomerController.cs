using BankingAppWebApi.enums;
using BankingAppWebApi.Interfaces;
using BankingAppWebApi.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IBankingDbRepository _bankingDbRepository;

        public CustomerController(IBankingDbRepository bankingDbRepository)
        {
            _bankingDbRepository = bankingDbRepository;
        }

        [HttpPost]
        public IActionResult CreateCustomer([FromBody] Customer customer)
        {
            try
            {
                if (customer == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.CustomerNotValid.ToString());
                }
                bool customerExists = _bankingDbRepository.DoesCustomerExistByEmailAddress(customer.EmailAddress);
                if (customerExists)
                {
                    return StatusCode(StatusCodes.Status409Conflict, SystemErrorCodes.CustomerDuplicate.ToString());
                }
                _bankingDbRepository.CreateNewCustomer(customer);
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.CustomerCreationFailed.ToString());
            }
            return Ok(customer);
        }

        [HttpGet]
        public IEnumerable<Customer> Get()
        {
            return _bankingDbRepository.GetAllCustomers();
        }

        // GET api/<CustomerController>/5
        [HttpGet("byid")]
        public Customer Get([FromQuery] int id)
        {
            return _bankingDbRepository.GetCustomerById(id);
        }

        [HttpGet("search")]
        public Customer Get([FromQuery] string lastName)
        {
            return _bankingDbRepository.GetCustomerByLastName(lastName);
        }

    }
}
