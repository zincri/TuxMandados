using System;
using TuxMandados.Helpers;
using TuxMandados.ViewModels;
using TuxMandados.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TuxMandados
{
    public partial class App : Application
    {
        public static NavigationPage Navigator { get; internal set; }
        public static AppTabbedPage Tabbed { get; internal set; }

        #region Properties
        #endregion
        public App()
        {
            InitializeComponent();
            if (String.IsNullOrEmpty(Settings.Token))
            {
                NavigationPage objeto = new NavigationPage(new LoginPage());
                objeto.BarBackgroundColor = Color.FromHex("#002E6D");
                objeto.BarTextColor = Color.FromHex("#EFCB4B");
                MainPage = objeto;
            }
            else
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = Settings.Token;
                mainViewModel.TokenType = Settings.TokenType;
                mainViewModel.LoadMenu();
                App.Current.MainPage = new NavigationPage(new AppTabbedPage())
                {
                    BarBackgroundColor = Color.FromHex("#002E6D"),
                    BarTextColor = Color.FromHex("#EFCB4B")

                };
                Navigator = (NavigationPage)MainPage;
            }

        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
