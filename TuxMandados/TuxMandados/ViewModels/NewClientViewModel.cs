namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;

    public class NewClientViewModel : INotifyPropertyChanged
    {
        #region Vars
        public event PropertyChangedEventHandler PropertyChanged;
        private string _nombre;
        private string _apellidos;
        private string _telefono;
        private string _direccion;
        private string _email;
        private string _password;
        private string _passwordconfirm;
        #endregion

        #region Properties
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
        #endregion

        #region Methods
        private async void SaveClientMethod()
        {
            await App.Current.MainPage.DisplayAlert(
                "Message",
                "Presionaste el botón",
                "Ok");
            return;

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
