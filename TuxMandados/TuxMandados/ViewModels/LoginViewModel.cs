namespace TuxMandados.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using TuxMandados.Views;
    using TuxMandados.Services;
    using TuxMandados.Helpers;
    using Xamarin.Forms;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private ApiService apiService;
        private bool _isRunning;
        private bool _isRemembered;
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
        public bool IsRemembered
        {
            get
            {
                return _isRemembered;
            }
            set
            {
                _isRemembered = value;
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
            this.apiService = new ApiService();
            this.Usuario = "usuario";
            this.Password = "123456";
            this.IsEnable = true;
            this.IsRunning =  false;
            this.IsRemembered =  false;
        
        }
        #endregion

        #region Methods


        private async void AccessMethod()
        {
            IsEnable = false;
            IsRunning = true;
            //Faltan las validaciones para el exceso de caracteres en los campos de usuario y contraseña
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await App.Current.MainPage.DisplayAlert(
                "Error",
                "El usuario está vacío!",
                "Ok");
                this.Password = string.Empty;
                IsRunning = false;
                IsEnable = true;
                return;
            }
            if (string.IsNullOrEmpty(this.Password))
            {
                await App.Current.MainPage.DisplayAlert(
                "Error",
                "La contraseña está vacía!",
                "Ok");
                this.Password = string.Empty;
                IsRunning = false;
                IsEnable = true;
                return;
            }
            //Antes de consumir el servicio valida hay que validar la conexion!

            var token = await this.apiService.GetToken(
                "http://servicio.bla.bla.net",
                this.Usuario,
                this.Password);
            if (token == null)
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                "Error",
                "Ocurrió algun problema!",
                "Ok");
                this.Password = string.Empty;
                return;

            }
            if (string.IsNullOrEmpty(token.AccessToken))
            {
                IsRunning = false;
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                "Error",
                token.ErrorDescription,
                "Ok");
                this.Password = string.Empty;
                return;
            }
            this.Password = string.Empty;
            IsEnable = true;
            IsRunning = false;

            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Token = token.AccessToken;
            mainViewModel.TokenType = token.TokenType;
            mainViewModel.LoadMenu();
            if (this.IsRemembered)
            {
                Settings.Token = token.AccessToken;
                Settings.TokenType = token.TokenType;
            }
            if(mainViewModel.TokenType.Equals("owner"))
            {
                App.Current.MainPage = new NavigationPage(new Views.Repartidor.R_AppTabbedPage())
                {
                    BarBackgroundColor = Color.FromHex("#33CAFF"),
                    BarTextColor = Color.FromHex("#000000")
                };
                App.Navigator = (NavigationPage)App.Current.MainPage;

            }
            else
            {
                App.Current.MainPage = new NavigationPage(new AppTabbedPage())
                {
                    BarBackgroundColor = Color.FromHex("#002E6D"),
                    BarTextColor = Color.FromHex("#EFCB4B")
                };
                App.Navigator = (NavigationPage)App.Current.MainPage;

            }

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
        
        private async void ForgotMethod()
        {
            IsEnable = false;
            IsRunning = true;
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Forgot = new ForgotViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new ForgotPage());
            IsEnable = true;
            IsRunning = false;

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
