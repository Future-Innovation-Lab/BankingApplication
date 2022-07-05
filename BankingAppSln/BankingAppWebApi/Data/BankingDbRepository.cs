using BankingAppWebApi.Interfaces;

namespace BankingAppWebApi.Data
{
    public class BankingDbRepository : IBankingDbRepository
    {
        private BankingContext _bankingContext;

        public BankingDbRepository(BankingContext bankingContext)
        {
            _bankingContext = bankingContext;
        }
    }
}
