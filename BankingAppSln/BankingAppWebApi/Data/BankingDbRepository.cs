using BankingAppWebApi.Interfaces;
using BankingAppWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace BankingAppWebApi.Data
{
    // TODO Split this repository into multiple repositories

    public class BankingDbRepository : IBankingDbRepository
    {
        private BankingContext _bankingContext;

        public BankingDbRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

        #region Customer


        public Customer CreateNewCustomer(Customer customer)
        {
            _bankingContext.Customers.Add(customer);
            _bankingContext.SaveChanges();

            return customer;
        }

        public bool DoesCustomerExistById(int id)
        {
            return _bankingContext.Customers.Any(cust => cust.CustomerId == id);
        }

        public bool DoesCustomerExistBySaIdNumber(string idNumber)
        {
            return _bankingContext.Customers.Any(cust => cust.IdNumber == idNumber);
        }

        public bool DoesCustomerExistByEmailAddress(string email)
        {
            return _bankingContext.Customers.Any(cust => cust.EmailAddress == email);
        }

        public List<Customer> GetAllCustomers(bool fullFetch = true)
        {
            if (fullFetch)
            {
                var customers = _bankingContext.Customers.Include(c => c.BankAccounts).ToList();
                return customers;
            }
            else
            {
                var customers = _bankingContext.Customers.ToList();
                return customers;
            }
        }

        public Customer GetCustomerById(int id, bool fullFetch=true)
        {
            if (fullFetch)
            {
                var customer = _bankingContext.Customers.Where(x => x.CustomerId == id).Include(c => c.BankAccounts).FirstOrDefault();
                return customer;
            }
            else
            {
                var customer = _bankingContext.Customers.Where(x => x.CustomerId == id).FirstOrDefault();
                return customer;
            }
        }

        public Customer GetCustomerByLastName(string surname, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var customer = _bankingContext.Customers.Where(x => x.Surname.Contains(surname)).Include(x => x.BankAccounts).FirstOrDefault();
                return customer;
            }
            else
            {
                var customer = _bankingContext.Customers.Where(x => x.Surname.Contains(surname)).FirstOrDefault();
                return customer;

            }
        }

        public Customer GetCustomerByEmail(string email, bool fullFetch = true)
        {
            if (fullFetch)
            {
                var customer = _bankingContext.Customers.Where(x => x.EmailAddress == email).Include(x => x.BankAccounts).Include(x => x.BankAccounts).FirstOrDefault();
                return customer;
            }
            else
            {
                var customer = _bankingContext.Customers.Where(x => x.EmailAddress == email).FirstOrDefault();
                return customer;

            }
        }

        public Customer GetCustomerBySaIdNumber(string idNumber, bool fullFetch=true)
        {
            if (fullFetch)
            {

                var customer = _bankingContext.Customers.Where(x => x.IdNumber == idNumber).Include(x => x.BankAccounts).FirstOrDefault();
                return customer;
            }

            else
            {
            var customer = _bankingContext.Customers.Where(x => x.IdNumber == idNumber).FirstOrDefault();
            return customer;

        }
    }


        #endregion


        #region BankAccount

        public BankAccount CreateNewBankAccount(BankAccount bankAccount)
        {
            _bankingContext.BankAccounts.Add(bankAccount);
            _bankingContext.SaveChanges();
            
            return bankAccount;
        }


        public IList<BankAccount> GetBankAccountsByCustomerId(int customerId)
        {
            var accounts = _bankingContext.BankAccounts.Where(x => x.CustomerId == customerId).ToList();
            return accounts;

        }
        
        public BankAccount GetBankAccountById(int bankAccountId)
        {
            var account = _bankingContext.BankAccounts.Where(x => x.BankAccountId == bankAccountId).FirstOrDefault();
            return account;

        }


        #endregion


        #region Transaction

        public Transaction CreateNewTransaction(Transaction transaction)
        {
            _bankingContext.Transactions.Add(transaction);
            _bankingContext.SaveChanges();

            return transaction;
        }


        public IList<Transaction> GetTransactionsByBankAccountId(int bankAccountId)
        {
            var transactions = _bankingContext.Transactions.Where(x => x.BankAccountId == bankAccountId).ToList();
            return transactions;
            
        }

        public Transaction GetTransactionById(int transactionId)
        {
            var transaction = _bankingContext.Transactions.Where(x => x.TransactionId == transactionId).FirstOrDefault();
            return transaction;
            
        }

        public IList<Transaction> GetTransactionsByBankAccountIdAndDate(int bankAccountId, DateTime startDate, DateTime endDate)
        {
            var transactions = _bankingContext.Transactions.Where(x => (x.BankAccountId == bankAccountId) && (x.TransactionDate >= startDate && x.TransactionDate <= endDate)).ToList();
            return transactions;

        }


        #endregion



        #region Authentication

        public bool PerformAuthenticationCheck(string userName, string pin)
        {
            var user = _bankingContext.Authentications.Where(u => u.EmailAddress == userName && u.Pin == pin).FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
        }

        #endregion

    }
}
