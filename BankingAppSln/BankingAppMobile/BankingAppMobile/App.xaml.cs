using BankingAppMobile.Services;
using BankingAppMobile.Services.Interfaces;
using BankingAppMobile.ViewModels;
using BankingAppMobile.Views;
using BankingAppMobile.Views.Dialogs;
using Prism;
using Prism.Ioc;
using Xamarin.Essentials.Implementation;
using Xamarin.Essentials.Interfaces;
using Xamarin.Forms;

[assembly: ExportFont("FontAwesome-Regular.ttf", Alias = "FontAwesome_Regular")]
[assembly: ExportFont("FontAwesome-Solid.ttf", Alias = "FontAwesome_Solid")]

[assembly: ExportFont("Mulish-Black.ttf", Alias = "Mulish_Black")]
[assembly: ExportFont("Mulish-Bold.ttf", Alias = "Mulish_Bold")]
[assembly: ExportFont("Mulish-ExtraBold.ttf", Alias = "Mulish_ExtraBold")]
[assembly: ExportFont("Mulish-ExtraLight.ttf", Alias = "Mulish_ExtraLight")]
[assembly: ExportFont("Mulish-Light.ttf", Alias = "Mulish_Light")]
[assembly: ExportFont("Mulish-Medium.ttf", Alias = "Mulish_Medium")]
[assembly: ExportFont("Mulish-Regular.ttf", Alias = "Mulish_Regular")]
[assembly: ExportFont("Mulish-SemiBold.ttf", Alias = "Mulish_SemiBold")]

namespace BankingAppMobile
{
    public partial class App
    {
        public App(IPlatformInitializer initializer)
            : base(initializer)
        {
        }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/SignInPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
        //   containerRegistry.RegisterRegionServices();

            containerRegistry.RegisterSingleton<IAppInfo, AppInfoImplementation>();
            containerRegistry.Register<IAuthentication, AuthenticationService> ();

            containerRegistry.Register<IAppConfiguration, AppConfigurationService>();

            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<ServiceTestPage, ServiceTestPageViewModel>();
            containerRegistry.RegisterForNavigation<SignInPage, SignInPageViewModel>();
            containerRegistry.RegisterForNavigation<SignUpPage, SignUpPageViewModel>();

            containerRegistry.RegisterDialog<ErrorDialog, ErrorDialogViewModel>();
            containerRegistry.RegisterForNavigation<HomePage, HomePageViewModel>();
        }
    }
}
