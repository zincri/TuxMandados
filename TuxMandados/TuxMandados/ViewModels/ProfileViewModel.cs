namespace TuxMandados.ViewModels
{
    using GalaSoft.MvvmLight.Command;
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;

    public class ProfileViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
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
        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
