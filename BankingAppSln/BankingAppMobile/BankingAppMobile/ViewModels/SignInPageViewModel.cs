using BankingAppMobile.Helpers;
using BankingAppMobile.Helpers.Validations;
using BankingAppMobile.Helpers.Validations.Rules;
using BankingAppMobile.Services.Interfaces;
using BankingAppMobile.Views.Dialogs;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.CommunityToolkit.UI.Views;

namespace BankingAppMobile.ViewModels
{
    public class SignInPageViewModel : ViewModelBase
    {
        private IAuthentication _authenticationService;
        private IDialogService _dialogService;
        private IEventAggregator _eventAggregator;

        private IDataCache _dataCache;

        private ValidatableObject<string> _email;
        public ValidatableObject<string> Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }

        private ValidatableObject<string> _pin;
        public ValidatableObject<string> Pin
        {
            get { return _pin; }
            set { SetProperty(ref _pin, value); }
        }

        

        private DelegateCommand _LoginCommand;
        public DelegateCommand LoginCommand =>
            _LoginCommand ?? (_LoginCommand = new DelegateCommand(ExecuteLoginCommand));

        private async void ExecuteLoginCommand()
        {
            try
            {
                MainState = LayoutState.Loading;
                if (ValidateLoginData())
                {
                    var authResponse = await _authenticationService.Authenticate(Email.Value, Pin.Value);

                    if (authResponse.Authenticated)
                    {
                        ClearAuthData();


                        // TODO set login state

                        _dataCache.IsAuthenticated = true;
                        _dataCache.AuthenticatedCustomer = authResponse.AuthenticatedCustomer;


                        await NavigationService.NavigateAsync("myapp:///NavigationPage/HomePage");

                    }
                    else
                    {
                        var param = new DialogParameters()
                        {
                            { "message", Constants.Errors.WrongUserOrPinError }
                        };
                        _dialogService.ShowDialog(nameof(ErrorDialog), param);
                    }
                }
            }
            catch (Exception ex)
            {
                var param = new DialogParameters()
                {
                    { "message", Constants.Errors.GeneralError }
                };
                _dialogService.ShowDialog(nameof(ErrorDialog), param);
            }
            finally
            {
                MainState = LayoutState.None;
            }
        }

        private DelegateCommand<string> _validateCommand;
        public DelegateCommand<string> ValidateCommand =>
            _validateCommand ?? (_validateCommand = new DelegateCommand<string>(ExecuteValidateCommand));

        private void ExecuteValidateCommand(string field)
        {
            switch (field)
            {
                case "email": Email.Validate(); break;
                case "pin": Pin.Validate(); break;
            }
        }

        private DelegateCommand _resetCommand;
        public DelegateCommand ResetCommand =>
            _resetCommand ?? (_resetCommand = new DelegateCommand(ExecuteResetCommand));

        void ExecuteResetCommand()
        {

        }

        private DelegateCommand _switchToSignUpCommand;
        public DelegateCommand SwitchToSignUpCommand =>
            _switchToSignUpCommand ?? (_switchToSignUpCommand = new DelegateCommand(ExecuteSwitchToSignUpCommand));

        private async void ExecuteSwitchToSignUpCommand()
        {
            await NavigationService.NavigateAsync("SignUpPage");
        }

        public SignInPageViewModel(INavigationService navigationService, IDialogService dialogService,
            IEventAggregator eventAggregator, IAuthentication authentication, IDataCache dataCache) : base(navigationService)
        {
            _dialogService = dialogService;
            _eventAggregator = eventAggregator;

            _authenticationService = authentication;

            _dataCache = dataCache;

            AddValidations();

        }

        public override void Initialize(INavigationParameters parameters)
        {
            Title = "Login";

        }

         

       
              private void AddValidations()
        {
            Email = new ValidatableObject<string>();
            Pin = new ValidatableObject<string>();

            Email.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A email is required." });
            Email.Validations.Add(new IsEmailRule<string> { ValidationMessage = "Email format is not correct" });
            Pin.Validations.Add(new IsNotNullOrEmptyRule<string> { ValidationMessage = "A pin is required." });
        }

        private bool ValidateLoginData()
        {
            Email.Validate(true);
                Pin.Validate(true);

            if (Email.IsValid == false ||
                Pin.IsValid == false)
                return false;
            return true;
        }

        private void ClearAuthData()
        {
            Email.Value = Pin.Value = string.Empty;
        }

       
    }
}
