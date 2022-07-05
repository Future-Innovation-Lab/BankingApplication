using BankingAppWebApi.Interfaces;
using BankingAppWebApi.Models;

namespace BankingAppWebApi.Data
{
    public class BankingDbRepository : IBankingDbRepository
    {
        private BankingContext _bankingContext;

        public BankingDbRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }

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

        public bool PerformAuthenticationCheck(string userName, string pin)
        {
            var user = _bankingContext.Authentications.Where(u => u.EmailAddress == userName && u.Pin == pin).FirstOrDefault();

            if (user != null)
            {
                return true;
            }

            return false;
        }

    }
}
