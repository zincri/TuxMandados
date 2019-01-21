namespace TuxMandados.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    public class MenuViewModel
    { 
        #region Commands

        public ICommand LogoutCommand
        {
            get
            {
                return new RelayCommand(ExitMethod);
            }
        }
        #endregion

        #region Methods
        private async void ExitMethod()
        {
            await App.Current.MainPage.DisplayAlert(
                "Mensaje",
                "Logout",
                "Ok");
        }
        #endregion
    }
}
