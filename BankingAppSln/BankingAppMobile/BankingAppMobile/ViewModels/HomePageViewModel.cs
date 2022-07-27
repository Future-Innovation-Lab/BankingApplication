using BankingAppMobile.Services.Interfaces;
using BankingAppWebApi.Models;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BankingAppMobile.ViewModels
{
    public class HomePageViewModel : ViewModelBase
    {
        private IDataCache _dataCache;

        private Customer _loggedInCustomer;
        public Customer LoggedInCustomer
        {
            get { return _loggedInCustomer; }
            set { SetProperty(ref _loggedInCustomer, value); }
        }

        private string _welcomeMessage;
        public string WelcomeMessage
        {
            get { return _welcomeMessage; }
            set { SetProperty(ref _welcomeMessage, value); }
        }


        public HomePageViewModel(INavigationService navigationService, IDataCache dataCache) : base(navigationService)
        {
            _dataCache = dataCache; 
        }
        
        public override void Initialize(INavigationParameters parameters)
        {
            Title = "Home";

            LoggedInCustomer = _dataCache.AuthenticatedCustomer;


            if (LoggedInCustomer != null)
            {
                WelcomeMessage = $"Welcome {LoggedInCustomer.FirstNames} {LoggedInCustomer.Surname}";

            }

        }
    }
}
