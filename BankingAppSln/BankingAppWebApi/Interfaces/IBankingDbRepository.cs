using BankingAppWebApi.Models;

namespace BankingAppWebApi.Interfaces
{
    public interface IBankingDbRepository
    {
        BankAccount CreateNewBankAccount(BankAccount bankAccount);
        Customer CreateNewCustomer(Customer customer);
        bool DoesCustomerExistByEmailAddress(string email);
        bool DoesCustomerExistById(int id);
        bool DoesCustomerExistBySaIdNumber(string idNumber);
        List<Customer> GetAllCustomers(bool fullFetch = true);
        IList<BankAccount> GetBankAccountsByCustomerId(int customerId);
        Customer GetCustomerByEmail(string email, bool fullFetch = true);
        Customer GetCustomerById(int id, bool fullFetch=true);
        Customer GetCustomerByLastName(string surname, bool fullFetch = true);
        Customer GetCustomerBySaIdNumber(string idNumber, bool fullFetch = true);
        bool PerformAuthenticationCheck(string userName, string pin);
    }
}
