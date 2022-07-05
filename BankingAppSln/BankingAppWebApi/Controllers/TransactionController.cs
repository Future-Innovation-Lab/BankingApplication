using BankingAppWebApi.enums;
using BankingAppWebApi.Interfaces;
using BankingAppWebApi.Models;
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

        [HttpPost]
        public IActionResult AddTransaction([FromBody] Transaction transaction)
        {
            try
            {
                if (transaction == null || !ModelState.IsValid)
                {
                    return BadRequest(SystemErrorCodes.CustomerNotValid.ToString());
                }
                BankAccount account = _bankingDbRepository.GetBankAccountById(transaction.BankAccountId);
                if (account != null)
                {
                    if ((transaction.TransactionTypeId == (int) TransactionTypeEnum.Withdrawal) && (transaction.Amount > account.AccountBalance))
                    {
                        return BadRequest(SystemErrorCodes.InsufficientFundsForTransaction.ToString());
                    }
                    else
                    {
                        transaction = _bankingDbRepository.CreateNewTransaction(transaction);
                    }
                }
                else
                {
                    return BadRequest(SystemErrorCodes.BankAccountNotValid.ToString());
                }
            }
            catch (Exception)
            {
                return BadRequest(SystemErrorCodes.CustomerCreationFailed.ToString());
            }
            return Ok(transaction);
        }

        [HttpGet("byBankAccountid")]
        public IList<Transaction> GetTranactionsByBankAccountId([FromQuery] int bankAccountId)
        {
            return _bankingDbRepository.GetTransactionsByBankAccountId(bankAccountId);
        }

        [HttpGet("byBankAccountDates")]
        public IList<Transaction> GetTranactionsByBankAccountId([FromQuery] int bankAccountId, DateTime startDate, DateTime endDate)
        {
            return _bankingDbRepository.GetTransactionsByBankAccountIdAndDate(bankAccountId, startDate, endDate);
        }


    }
}
