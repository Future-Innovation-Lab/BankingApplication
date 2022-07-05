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
    }
}
