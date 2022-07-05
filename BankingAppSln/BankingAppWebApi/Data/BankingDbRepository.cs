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
                var customer = _bankingContext.Customers.Where(x => x.Surname == surname).Include(x => x.BankAccounts).FirstOrDefault();
                return customer;
            }
            else
            {
                var customer = _bankingContext.Customers.Where(x => x.Surname == surname).FirstOrDefault();
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
