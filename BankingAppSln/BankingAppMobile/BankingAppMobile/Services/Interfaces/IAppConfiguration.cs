using System;
using System.Collections.Generic;
using System.Text;

namespace BankingAppMobile.Services.Interfaces
{
    public interface IAppConfiguration
    {
        string BankingServerUrl { get; set; }
    }
}
