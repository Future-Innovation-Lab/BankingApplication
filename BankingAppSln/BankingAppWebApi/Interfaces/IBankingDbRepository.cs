using BankingAppWebApi.Models;

namespace BankingAppWebApi.Interfaces
{
    public interface IBankingDbRepository
    {
        Customer CreateNewCustomer(Customer customer);
    }
}
