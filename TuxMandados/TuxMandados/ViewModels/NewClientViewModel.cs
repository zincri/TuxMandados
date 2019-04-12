namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using Plugin.Media;
    using Plugin.Media.Abstractions;
    using TuxMandados.Helpers;
    using TuxMandados.Services;
    using Xamarin.Forms;
    using TuxMandados.Views;
    using Domain;
    using TuxMandados.Models;
    using Acr.UserDialogs;
    using System.Threading.Tasks;

    public class NewClientViewModel : INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Vars
        public SolicitudACUsuario solicitud;
        public event PropertyChangedEventHandler PropertyChanged;
        private string _usuario;
        private string _nombre;
        private string _apePat;
        private string _apeMat;
        private string _telefono;
        private string _direccion;
        private string _email;
        private string _password;
        private DateTime _fecha;
        private string _passwordconfirm;
        private bool _isRunning;
        private bool _isEnabled;
        private decimal _latitud;
        private decimal _longitud;
        private ImageSource _imageSource;
        private MediaFile file;
        #endregion

        #region Constructor
        public NewClientViewModel()
        {
           
            this.apiService = new ApiService();
            this.IsEnabled = true;
            this.ImageSource = "no_image";

        }
        #endregion

        #region Properties
        public ImageSource ImageSource
        {
            get
            {
                return _imageSource;
            }
            set
            {
                _imageSource = value;
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
        public bool IsEnabled
        {
            get
            {
                return _isEnabled;
            }
            set
            {
                _isEnabled = value;
                OnPropertyChanged();
            }
        }
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
        public string Nombre
        {
            get
            {
                return _nombre;
            }
            set
            {
                _nombre = value;
                OnPropertyChanged();
            }
        }
        public string ApePat
        {
            get
            {
                return _apePat;
            }
            set
            {
                _apePat = value;
                OnPropertyChanged();
            }
        }
        public string ApeMat
        {
            get
            {
                return _apeMat;
            }
            set
            {
                _apeMat = value;
                OnPropertyChanged();
            }
        }
        public string Telefono
        {
            get
            {
                return _telefono;
            }
            set
            {
                _telefono = value;
                OnPropertyChanged();
            }
        }
        public decimal Latitud
        {
            get
            {
                return _latitud;
            }
            set
            {
                _latitud = value;
                OnPropertyChanged();
            }
        }
        public decimal Longitud
        {
            get
            {
                return _longitud;
            }
            set
            {
                _longitud = value;
                OnPropertyChanged();
            }
        }
        public DateTime Fecha
        {
            get
            {
                return _fecha;
            }
            set
            {
                _fecha = value;
                OnPropertyChanged();
            }
        }
        public string Direccion
        {
            get
            {
                return _direccion;
            }
            set
            {
                _direccion = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get
            {
                return _email;
            }
            set
            {
                _email = value;
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
        public string PasswordConfirm
        {
            get
            {
                return _passwordconfirm;
            }
            set
            {
                _passwordconfirm = value;
                OnPropertyChanged();
            }
        }
        #endregion

        #region Commands

        public ICommand SaveClientCommand
        {
            get
            {
                return new RelayCommand(SaveClientMethod);
            }
        }
        public ICommand ChangeImageCommand
        {
            get
            {
                return new RelayCommand(ChangeImageMethod);
            }
        }
        #endregion
                                                                                                                               
        #region Methods
        private async void SaveClientMethod()
        {
            if (string.IsNullOrEmpty(this.Usuario))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo usuario está vacío!",
                    "Ok");
                return;
            }
            if (string.IsNullOrEmpty(this.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo nombre está vacío!",
                    "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.ApePat))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El apellido paterno esta vacio",
                    "Ok");
                return;
            }
            if (string.IsNullOrEmpty(this.ApeMat))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El apellido materno esta vacìo",
                    "Ok");
                return;
            }
            if (string.IsNullOrEmpty(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo email está vacío!",
                    "Ok");
                return;
            }
            // Valida
            if (this.Fecha.Year >= 2003)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El seleccione una fecha",
                    "Ok");
                return;
            }

            if (!RegexUtilities.IsValidEmail(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "¡¡Ingresa un correo valido !!",
                    "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Telefono))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo telefono está vacío!",
                    "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Password))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo contraseña está vacío!",
                    "Ok");
                return;
            }

            if (this.Password.Length < 6)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo contraseña debe tener almenos 6 caracteres!",
                    "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.PasswordConfirm))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "¡¡Confirma tu contraseña!!",
                    "Ok");
                return;
            }

            if (this.Password != this.PasswordConfirm)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "¡¡ Las contraseñas no coinciden!!",
                    "Ok");
                return;
            }

            this.IsRunning = true;
            this.IsEnabled = false;

            var checkConnetion = await this.apiService.CheckConnection();
            if (!checkConnetion.IsSuccess)
            {
                this.IsRunning = false;
                this.IsEnabled = true;
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Checa tu conexion a internet!",
                    "Ok");
                return;
            }
            /*
            byte[] imageArray = null;
            if (this.file != null)
            {
                imageArray = FilesHelper.ReadFully(this.file.GetStream());
            }
            //Crear la var de user de acuerdo a los campos que tiene la base de datos!
            var user = new User
            {
                Email = this.Email,
                Nombre = this.Nombre,
                Apellidos = this.Apellidos,
                Telefono = this.Telefono,
                ImageArray = imageArray,
                Password = this.Password
            };*/            
            CallService();
        }
        private void CallService()
        {

            bool success = false;
            string msg="";
            try
            {
                Device.BeginInvokeOnMainThread(() => UserDialogs.Instance.ShowLoading("Registrando nuevo Tuxmandador...", MaskType.Black));
                Task.Run(async () =>
                {

                    solicitud = new SolicitudACUsuario();
                    solicitud.opcion = 1;
                    solicitud.usuario = Usuario;
                    solicitud.email = Email;
                    solicitud.password = Password;
                    solicitud.nombre = Nombre;
                    solicitud.ape_pat = ApePat;
                    solicitud.ape_mat = ApeMat;
                    solicitud.direccion = Direccion;
                    solicitud.fecha = Fecha.ToString("yyyy-MM-dd");
                    solicitud.telefono = Telefono;
                    solicitud.latitud = 19.365M;
                    solicitud.longitud = 78.32M;
                    solicitud.cambioPass = false;
                    solicitud.idcli = 0;
                    solicitud.idloc = 0;
                    solicitud.idusu = 0;
                    var res = await this.apiService.SetUsuario(
                "http://www.creativasoftlineapps.com/ScriptAppTuxmandados/frmACUsuario.aspx",
                solicitud);
                    if (res != null)
                    {
                       
                        success = true;
                    }
                    else
                    {
                        msg=res.ErrorDescription;
                    }
                }).ContinueWith(res => Device.BeginInvokeOnMainThread(async () =>
                {
                    if (success == false)
                    {
                        await App.Current.MainPage.DisplayAlert("Ocurrió un error", msg, "Aceptar");
                        UserDialogs.Instance.HideLoading();

                    }
                    else
                    {                       
                        UserDialogs.Instance.HideLoading();
                        await App.Current.MainPage.DisplayAlert("Éxito", "Registro realizado correctamente", "ok");
                        await App.Current.MainPage.Navigation.PopAsync();
                    }
                }));
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Ocurrió un error", ex.ToString(), "Aceptar");
            }

        }
        private async void ChangeImageMethod()
        {
            await CrossMedia.Current.Initialize();

            if (CrossMedia.Current.IsCameraAvailable &&
                CrossMedia.Current.IsTakePhotoSupported)
            {
                var source = await Application.Current.MainPage.DisplayActionSheet(
                    "¿De donde quieres tomar la imagen?",
                    "Cancelar",
                    null,
                    "Desde la galería",
                    "Desde la cámara");

                if (source == "Cancelar")
                {
                    this.file = null;
                    return;
                }

                if (source == "Desde la cámara")
                {
                    try 
                    {
                        this.file = await CrossMedia.Current.TakePhotoAsync(
                        new StoreCameraMediaOptions
                        {
                            Directory = "Sample",
                            Name = "test.jpg",
                            PhotoSize = PhotoSize.Small,
                        }
                    );

                    } 
                    catch (Exception ex) 
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Mensaje",
                            "No tienes permisos! Ve a los ajustes de la aplicacion, y habilita la camara.",
                            "Ok");
                        return;
                    }
                }
                else
                {
                    try
                    {
                        this.file = await CrossMedia.Current.PickPhotoAsync();
                    }
                    catch (Exception ex)
                    {
                        await Application.Current.MainPage.DisplayAlert(
                            "Mensaje",
                            "No tienes permisos! Ve a los ajustes de la aplicacion, y habilita la camara.",
                            "Ok");
                        return;
                    }

                }
            }
            else
            {
                try
                {
                    this.file = await CrossMedia.Current.PickPhotoAsync();
                }
                catch (Exception ex)
                {
                    await Application.Current.MainPage.DisplayAlert(
                            "Mensaje",
                            "No tienes permisos! Ve a los ajustes de la aplicacion, y habilita la camara.",
                            "Ok");
                    return;
                }
            }

            if (this.file != null)
            {
                this.ImageSource = ImageSource.FromStream(() =>
                {
                    var stream = file.GetStream();
                    return stream;
                });
            }
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
