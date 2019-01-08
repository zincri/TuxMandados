using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace TuxMandados
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            NavigationPage objeto = new NavigationPage(new Views.StartPage());
            MainPage = objeto;
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
