using BankingAppWebApi.Models;

namespace BankingAppWebApi.Interfaces
{
    public interface IBankingDbRepository
    {
        Customer CreateNewCustomer(Customer customer);
        bool DoesCustomerExistByEmailAddress(string email);
        bool DoesCustomerExistById(int id);
        bool DoesCustomerExistBySaIdNumber(string idNumber);
    }
}
