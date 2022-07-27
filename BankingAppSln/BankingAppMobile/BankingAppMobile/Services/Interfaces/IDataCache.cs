using BankingAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMobile.Services.Interfaces
{
    public interface IDataCache
    {
        bool IsAuthenticated { get; set; }

        Customer AuthenticatedCustomer { get; set; }
    }
}
