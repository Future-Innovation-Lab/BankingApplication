using Microsoft.EntityFrameworkCore;

namespace BankingAppWebApi.Data
{
    public class BankingContext
          : DbContext
    {
        public BankingContext(DbContextOptions options)
            : base(options)
        {

        }
    }
}
