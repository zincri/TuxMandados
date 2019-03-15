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
    using TuxMandados.Models;
    using TuxMandados.Services;

    public class NewOrderViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private ApiService apiService;
        private bool _isRunning;
        private bool _isEnable;
        private bool _ubicacion;
        private bool _llamar;
        private string _descripcion;
        private string _lugarmandado;
        private string _lugarentrega;
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
        public string LugarMandado
        {
            get
            {
                return _lugarmandado;
            }
            set
            {
                _lugarmandado = value;
                OnPropertyChanged();
            }
        }
        public string LugarEntrega
        {
            get
            {
                return _lugarentrega;
            }
            set
            {
                _lugarentrega = value;
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
            this.apiService = new ApiService();
            this.Descripcion = "Desc";
            this.LugarMandado = "Manda";
            this.LugarEntrega = "Direc";
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

            // Hay que comentar esto por que no nos sirve de nada.
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
                await App.Current.MainPage.DisplayAlert("Incorrecto", "Algo ocurrió,por favor active el uso de ubicacion en sus ajustes!", "ok");
            }
            else {
                Order solicitud = new Order();// hacemos el objeto order, para mandarlo al servicio!
                SolicitudSetOrder solicitudSetOrder = new SolicitudSetOrder();
                solicitud.Estado = 1;
                solicitud.Descripcion = Descripcion;
                solicitud.Ubicacion = new Ubicacion();
                solicitud.Ubicacion.Latitud = pin.Position.Latitude;
                solicitud.Ubicacion.Longitud = pin.Position.Longitude;
                solicitudSetOrder.Order = solicitud;
                solicitudSetOrder.IDUsuario = 3;
                solicitudSetOrder.IDCliente = 12;
                

                var token = await this.apiService.SetOrder(
                "http://www.creativasoftlineapps.com/ScriptAppTuxmandados/frmSetOrder.aspx",
                solicitudSetOrder);
                await App.Current.MainPage.DisplayAlert("Correcto", "Tuxmandado", "ok");
            }

        }

        private async Task<Pin> UseUbicationMethod()
        {
            try
            {
                var request = new GeolocationRequest(GeolocationAccuracy.High);
                var location = await Geolocation.GetLocationAsync(request);
                //var location = await Geolocation.GetLastKnownLocationAsync();

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
                //Activa en ajustes tu uso de ubicacion
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
