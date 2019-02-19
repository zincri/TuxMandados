namespace TuxMandados.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using TuxMandados.Views;
    public class NewOrderViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private bool _isRunning;
        private bool _isEnable;
        private bool _ubicacion;
        private bool _llamar;
        private string _descripcion;
        private string _lmandado;
        private string _lentrega;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
        public bool Ubicacion
        {
            get
            {
                return _ubicacion;
            }
            set
            {
                _ubicacion = value;
                OnPropertyChanged();
            }
        }
        public bool Llamar
        {
            get
            {
                return _llamar;
            }
            set
            {
                _llamar = value;
                OnPropertyChanged();
            }
        }
        public string Descripcion
        {
            get
            {
                return _descripcion;
            }
            set
            {
                _descripcion = value;
                OnPropertyChanged();
            }
        }
        public string LMandado
        {
            get
            {
                return _lmandado;
            }
            set
            {
                _lmandado = value;
                OnPropertyChanged();
            }
        }
        public string LEntrega
        {
            get
            {
                return _lentrega;
            }
            set
            {
                _lentrega = value;
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

        public ICommand MapCommand
        {
            get
            {
                return new RelayCommand(MapMethod);
            }
        }
        public ICommand SendCommand
        {
            get
            {
                return new RelayCommand(SendMethod);
            }
        }

        #endregion

        #region Constructors
        public NewOrderViewModel()
        {
            this.Descripcion = "Desc";
            this.LMandado = "Manda";
            this.LEntrega = "Direc";
            this.Llamar = false;
            this.Ubicacion = true;
            this.IsEnable = true;
            this.IsRunning = false;
        }
        #endregion

        #region Methods


        private async void MapMethod()
        {
            IsEnable = false;
            IsRunning = true;
            //  var mainViewModel = MainViewModel.GetInstance();
            //  mainViewModel.Home = new HomeViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new SMapPage());
            IsEnable = true;
            IsRunning = false;
        }



        private async void SendMethod()
        {

            await App.Current.MainPage.DisplayAlert("Correcto", "Tuxmandado", "ok");
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
