using BankingAppWebApi.Models;

namespace BankingAppWebApi.Interfaces
{
    public interface IBankingDbRepository
    {
        Customer CreateNewCustomer(Customer customer);
        bool DoesCustomerExistByEmailAddress(string email);
        bool DoesCustomerExistById(int id);
        bool DoesCustomerExistBySaIdNumber(string idNumber);
        List<Customer> GetAllCustomers(bool fullFetch = true);
        Customer GetCustomerByEmail(string email, bool fullFetch = true);
        Customer GetCustomerById(int id, bool fullFetch=true);
        Customer GetCustomerByLastName(string surname, bool fullFetch = true);
        Customer GetCustomerBySaIdNumber(string idNumber, bool fullFetch = true);
        bool PerformAuthenticationCheck(string userName, string pin);
    }
}
