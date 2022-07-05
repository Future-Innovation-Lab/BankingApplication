using BankingAppWebApi.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BankingAppWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransactionController : ControllerBase
    {
        private readonly IBankingDbRepository _bankingDbRepository;

        public TransactionController(IBankingDbRepository bankingDbRepository)
        {
            _bankingDbRepository = bankingDbRepository;
        }

    }
}
