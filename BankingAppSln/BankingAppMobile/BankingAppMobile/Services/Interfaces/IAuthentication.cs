using BankingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BankingAppMobile.Services.Interfaces
{
    public interface IAuthentication
    {
        Task<AuthResponse> Authenticate(string userName, string pin);
    }
}
