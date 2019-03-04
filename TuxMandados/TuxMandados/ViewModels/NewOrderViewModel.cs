namespace TuxMandados.ViewModels
{
    using System;
    using GalaSoft.MvvmLight.Command;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using TuxMandados.Views;
    using Xamarin.Forms.GoogleMaps;
    using Xamarin.Essentials;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

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
        public static Pin pin;
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
            //pin = new Pin();
            await App.Current.MainPage.Navigation.PushAsync(new SMapPage());
            if(pin == null)
            {
                //await App.Current.MainPage.DisplayAlert("Mensaje", "pin null", "ok");
            }
            IsEnable = true;
            IsRunning = false;
        }


        private async void SendMethod()
        {
            /*antes de cada servicio comprueba la conexion*/

            /*Modal que bloquee la pantalla*/
            ModalMapPage modalPage = new ModalMapPage();
            await App.Navigator.Navigation.PushModalAsync(modalPage);
            if (Ubicacion) 
            {
                var t = await UseUbicationMethod();
            }

            await App.Navigator.Navigation.PopModalAsync();
            if (pin == null) {
                await App.Current.MainPage.DisplayAlert("Incorrecto", "Algo ocurrió,por favor intente mas tarde!", "ok");
            }
            else {
                await App.Current.MainPage.DisplayAlert("Correcto", "Tuxmandado", "ok");
            }

        }

        private async Task<Pin> UseUbicationMethod()
        {
            try
            {
                var location = await Geolocation.GetLastKnownLocationAsync();

                if (location != null)
                {
                    Geocoder geo = new Geocoder();
                    Position posicion = new Position(location.Latitude, location.Longitude);
                    IEnumerable<string> adresses = await geo.GetAddressesForPositionAsync(posicion);
                    pin = new Pin()
                    {
                        Type = PinType.Place,
                        Label = "Lugar",
                        Address = adresses.ElementAt(0),
                        Position = new Position(posicion.Latitude, posicion.Longitude)
                    };
                    return pin;
                    //Console.WriteLine($"Latitude: {location.Latitude}, Longitude: {location.Longitude}, Altitude: {location.Altitude}");
                }
                return null;
            }
            catch (FeatureNotSupportedException fnsEx)
            {
                return null;
                // Handle not supported on device exception
            }
            catch (FeatureNotEnabledException fneEx)
            {
                return null;
                // Handle not enabled on device exception
            }
            catch (PermissionException pEx)
            {
                return null;
                // Handle permission exception
            }
            catch (Exception ex)
            {
                return null;
                // Unable to get location
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
