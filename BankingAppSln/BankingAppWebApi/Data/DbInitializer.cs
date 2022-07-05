using BankingAppWebApi.Models;

namespace BankingAppWebApi.Data
{
    public class DbInitialiser
    {
        private readonly BankingContext _context;

        public DbInitialiser(BankingContext context)
        {
            _context = context;
        }

        public void Run()
        {
            if (!_context.TransactionTypes.Any())
            {

                var transactionType = new TransactionType();
                transactionType.Description = "Add Funds";
                _context.TransactionTypes.Add(transactionType);

                transactionType = new TransactionType();
                transactionType.Description = "Withdraw Funds";
                _context.TransactionTypes.Add(transactionType);

                _context.SaveChanges();
            }

            if (!_context.BankAccountTypes.Any())
            {
                var accountType = new BankAccountType();
                accountType.Description = "Savings";
                _context.BankAccountTypes.Add(accountType);

                accountType = new BankAccountType();
                accountType.Description = "Cheque";
                _context.BankAccountTypes.Add(accountType);

                accountType = new BankAccountType();
                accountType.Description = "Credit";
                _context.BankAccountTypes.Add(accountType);

                _context.SaveChanges();
            }
        }
    }
}
