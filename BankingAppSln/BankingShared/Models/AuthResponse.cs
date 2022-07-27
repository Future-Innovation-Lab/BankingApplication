using BankingAppWebApi.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankingShared.Models
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public Customer AuthenticatedCustomer { get; set; }

        public AuthResponse()
        {
            Authenticated = false;
            AuthenticatedCustomer = null;
        }
    }
}
