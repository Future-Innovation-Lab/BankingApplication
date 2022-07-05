using BankingAppWebApi.Models;

namespace BankingAppWebApi.Interfaces
{
    public interface IBankingDbRepository
    {
        BankAccount CreateNewBankAccount(BankAccount bankAccount);
        Customer CreateNewCustomer(Customer customer);
        Transaction CreateNewTransaction(Transaction transaction);
        bool DoesCustomerExistByEmailAddress(string email);
        bool DoesCustomerExistById(int id);
        bool DoesCustomerExistBySaIdNumber(string idNumber);
        List<Customer> GetAllCustomers(bool fullFetch = true);
        BankAccount GetBankAccountById(int bankAccountId);
        IList<BankAccount> GetBankAccountsByCustomerId(int customerId);
        Customer GetCustomerByEmail(string email, bool fullFetch = true);
        Customer GetCustomerById(int id, bool fullFetch=true);
        Customer GetCustomerByLastName(string surname, bool fullFetch = true);
        Customer GetCustomerBySaIdNumber(string idNumber, bool fullFetch = true);
        IList<Transaction> GetTransactionsByBankAccountId(int bankAccountId);
        IList<Transaction> GetTransactionsByBankAccountIdAndDate(int bankAccountId, DateTime startDate, DateTime endDate);
        Transaction GetTransactionById(int transactionId);
        bool PerformAuthenticationCheck(string userName, string pin);
        
    }
}
