using BankingAppMobile.Services.Interfaces;
using BankingAppWebApi.Models;

namespace BankingAppMobile.Services
{
    public class InMemoryDataCache : IDataCache
    {
        public bool IsAuthenticated { get; set; }
        public Customer AuthenticatedCustomer { get; set; }
    }
}
