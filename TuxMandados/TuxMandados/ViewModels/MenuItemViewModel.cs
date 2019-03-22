namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Helpers;
    using TuxMandados.Views;
    using Xamarin.Forms;

    public class MenuItemViewModel
    {
        public string Icon { get; set; }
        public string Title { get; set; }
        public string NamePage { get; set; }
        #region Commands

        public ICommand NavigateCommand
        {
            get
            {
                return new RelayCommand(NavigateMethod);
            }
        }
        #endregion

        #region Methods
        private void NavigateMethod()
        {
            if(this.NamePage=="LoginPage") 
            {
                Settings.Token = String.Empty;
                Settings.TokenType = String.Empty;
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Token = String.Empty;
                mainViewModel.TokenType = 0;
                //App.Current.MainPage = new LoginPage();
                NavigationPage objeto = new NavigationPage(new LoginPage());
                objeto.BarBackgroundColor = Color.FromHex("#002E6D");
                objeto.BarTextColor = Color.FromHex("#EFCB4B");
                App.Current.MainPage = objeto;
            }
            else if (this.NamePage=="Perfil")
            {
                var mainViewModel = MainViewModel.GetInstance();
                mainViewModel.Profile = new ProfileViewModel();
                App.Current.MainPage.Navigation.PushAsync(new EditClientPage());
            }

        }
        #endregion
    }
}
