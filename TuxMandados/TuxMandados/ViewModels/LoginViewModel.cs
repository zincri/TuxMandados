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
    using TuxMandados.Models;
    using Acr.UserDialogs;
    using System.Threading.Tasks;

    public class LoginViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private ApiService apiService;
        string TokenAccess,TokenType,msgError;
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
            this.Usuario = "eacr77";
            this.Password = "123456";
            this.IsEnable = true;
            this.IsRunning =  false;
            this.IsRemembered =  false;
        
        }
        #endregion

        #region MethodsAccessToken


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
                IsEnable = true;
                return;
            }
            //Antes de consumir el servicio valida hay que validar la conexion!
            var conection = await this.apiService.CheckConnection();
            if (!conection.IsSuccess)
            {               
                IsEnable = true;
                await App.Current.MainPage.DisplayAlert(
                "Error",
                "Checa tu conexion a internet!",
                "Ok");
                this.Password = string.Empty;
                return;
            }
            CallService();
           

        }

        private void CallService()
        {
            bool success = false;
            try
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Accesando a Tuxmandados...", MaskType.Black));
                Task.Run(async () =>
                {
                    SolicitudLogin solicitud = new SolicitudLogin();
                    solicitud.usuario = Usuario;
                    solicitud.password = Password;
                    var res = await this.apiService.GetToken(
                        "http://www.creativasoftlineapps.com/ScriptAppTuxmandados/frmLogin.aspx",
                        solicitud);
                    if (res != null)
                    {
                        TokenAccess = res.AccessToken;
                        TokenType = res.TokenType;
                        success = true;
                        msgError = res.ErrorDescription;
                    }                   
                    
                }).ContinueWith(res => Device.BeginInvokeOnMainThread(async () =>
                {
                    if (success == false)
                    {
                        await App.Current.MainPage.DisplayAlert("Ocurrió un error", "El acceso no es válido", "Aceptar");
                        UserDialogs.Instance.HideLoading();

                    }
                    else
                    {                        
                        UserDialogs.Instance.HideLoading();
                        if (string.IsNullOrEmpty(TokenAccess))
                        {

                            IsEnable = true;
                            await App.Current.MainPage.DisplayAlert(
                            "Error",
                            msgError,
                            "Ok");
                            this.Password = string.Empty;
                            return;
                        }
                        this.Password = string.Empty;
                        IsEnable = true;


                        var mainViewModel = MainViewModel.GetInstance();
                        mainViewModel.Token = TokenAccess;
                        mainViewModel.TokenType = TokenType;
                        mainViewModel.LoadMenu();
                        if (this.IsRemembered)
                        {
                            Settings.Token = TokenAccess;
                            Settings.TokenType = TokenAccess;
                        }
                        if (mainViewModel.TokenType.Equals("repartidor"))
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
                }));
            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Ocurrió un error", ex.ToString(), "Aceptar");
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
