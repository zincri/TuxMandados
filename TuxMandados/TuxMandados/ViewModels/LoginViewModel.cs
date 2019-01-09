using System;
using System.Collections.Generic;
using System.Text;

namespace TuxMandados.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Services;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using TuxMandados.Views;

    public class LoginViewModel : INotifyPropertyChanged
    {                
        #region Vars        
        private bool _isEnable;
        private string _usuario;
        private string _password;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
        public string Usuario
        {
            get
            {
                return _usuario;
            }
            set
            {
                _usuario = value;
                OnPropertyChanged();
            }
        }
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                _password = value;
                OnPropertyChanged();
            }
        }
        public bool IsEnable
        {
            get
            {
                return _isEnable;
            }
            set
            {
                _isEnable = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands
        
        public ICommand LoginCommand
        {
            get
            {
                return new RelayCommand(AccessMethod);
            }
        }
        public ICommand ForgotPassword
        {
            get
            {
                return new RelayCommand(ForgotMethod);
            }
        }
        


        #endregion

        #region Constructors
        public LoginViewModel()
        {
            Usuario = "XXXU";
            Password = "XXXP";
            IsEnable = true;
        
        }
        #endregion

        #region Methods


        private async void AccessMethod()
        {
            IsEnable = false;
            var mainViewModel = MainViewModel.GetInstance();

            mainViewModel.Home = new HomeViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new Views.HomePage());

            IsEnable = true;
        }

        private void ForgotMethod()
        {
            
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
