namespace TuxMandados.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using TuxMandados.Views;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private bool _isRunning;
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
        public bool IsRunning
        {
            get
            {
                return _isRunning;
            }
            set
            {
                _isRunning = value;
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
        public ICommand RegisterCommand
        {
            get
            {
                return new RelayCommand(RegisterMethod);
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
            this.Usuario = "UserEjemplo";
            this.Password = "Passejemplo";
            this.IsEnable = true;
            this.IsRunning =  false;
        
        }
        #endregion

        #region Methods


        private async void AccessMethod()
        {
            IsEnable = false;
            IsRunning = true;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Home = new HomeViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new HomeTabbedPage());
            IsEnable = true;
            IsRunning = false;
        }


        private async void RegisterMethod()
        {
            IsEnable = false;
            IsRunning = true;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.NewClient = new NewClientViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new NewClientPage());
            IsEnable = true;
            IsRunning = false;
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
