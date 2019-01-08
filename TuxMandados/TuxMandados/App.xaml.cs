using System;
using TuxMandados.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TuxMandados
{
    public partial class App : Application
    {

        #region Properties

        #endregion
        public App()
        {
            InitializeComponent();

            NavigationPage objeto = new NavigationPage(new LoginPage());
            MainPage = objeto;
            //MainPage = new MasterTuxMandPage();
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
