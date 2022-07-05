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


            if (!_context.Customers.Any())
            {

                var customer = new Customer();
                customer.FirstNames = "Chuck";
                customer.Surname = "Norris";
                customer.CellPhoneNumber = "5553232";
                customer.EmailAddress = "me@computer.com";
                customer.IdNumber = "4432125032086";
                customer.ResidentialAddress = "1428 Elm Street";

                var bankAccount = new BankAccount();
                bankAccount.AccountNumber = "53435434543";
                bankAccount.BankAccountTypeId = 1;
                bankAccount.AccountBalance = 10000;


                var userAccount = new Authentication();
                userAccount.EmailAddress = "me@computer.com";
                userAccount.Pin = "12345";
                userAccount.Enabled = true;

                customer.BankAccounts = new List<BankAccount>();
                customer.BankAccounts.Add(bankAccount);

                customer.Authentication = userAccount;

                var transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.TransactionTypeId = 1;
                transaction.BankAccount = bankAccount;
                transaction.Amount = 50;
                transaction.Description = "Salary deposit";
                transaction.Reference = "FUT123";

                bankAccount.Transactions = new List<Transaction>();

                bankAccount.Transactions.Add(transaction);

                _context.Transactions.Add(transaction);

                transaction = new Transaction();
                transaction.TransactionDate = DateTime.Now;
                transaction.TransactionTypeId = 2;
                transaction.BankAccount = bankAccount;
                transaction.Amount = 200;
                transaction.Description = "Lunch Money";
                transaction.Reference = "LUNCH";

                bankAccount.Transactions.Add(transaction);

                _context.Transactions.Add(transaction);

                _context.Customers.Add(customer);
                _context.BankAccounts.Add(bankAccount);
                _context.Authentications.Add(userAccount);
                _context.SaveChanges();
            }

        }
    }
}
