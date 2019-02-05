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
    using Domain;

    public class NewClientViewModel : INotifyPropertyChanged
    {
        #region Services
        private ApiService apiService;
        #endregion

        #region Vars
        public event PropertyChangedEventHandler PropertyChanged;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        private string _email;
        private string _password;
        private string _passwordconfirm;
        private bool _isRunning;
        private bool _isEnabled;
        private ImageSource _imageSource;
        private MediaFile file;
        #endregion

        #region Constructor
        public NewClientViewModel()
        {
            this.Nombre = "Nombre_Ejemplo";
            this.Apellidos = "Apellidos_Ejemplo";
            this.Telefono = "Tele_Ejemplo";
            this.Direccion = "Direccion_Ejemplo";
            this.Email = "Email_Ejemplo";
            this.Password = "Pass_Ejemplo";
            this.PasswordConfirm = "ConPass_Ejemplo";
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
        public string Apellidos
        {
            get
            {
                return _apellidos;
            }
            set
            {
                _apellidos = value;
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
            /*
            await App.Current.MainPage.DisplayAlert(
                "Message",
                "Presionaste el botón",
                "Ok");
            return;
            */
            if (string.IsNullOrEmpty(this.Nombre))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo nombre está vacío!",
                    "Ok");
                return;
            }

            if (string.IsNullOrEmpty(this.Apellidos))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "Los apellidos están vacíos!",
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

            if (!RegexUtilities.IsValidEmail(this.Email))
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "El campo email es incorrecto!",
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
                    "El campo confirmacion de contraseña está vacío!",
                    "Ok");
                return;
            }

            if (this.Password != this.PasswordConfirm)
            {
                await Application.Current.MainPage.DisplayAlert(
                    "Error",
                    "La contraseña no coincide con la confirmacion de la contraseña!",
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
            };

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
