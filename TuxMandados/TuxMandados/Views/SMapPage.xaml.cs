using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.GoogleMaps;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuxMandados.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SMapPage : ContentPage
    {
        string direcc;
        Geocoder geo = new Geocoder();
        Pin _pin;
        public SMapPage()
        {
            InitializeComponent();
            map.MoveToRegion(
               MapSpan.FromCenterAndRadius(
                   new Position(16.7514123, -93.1393565), Distance.FromMiles(3)));


            map.PinDragEnd += async (sender, e) => {
                var lat = _pin.Position.Latitude;
                var lon = _pin.Position.Longitude;
                IEnumerable<string> Adresses = await geo.GetAddressesForPositionAsync(_pin.Position);
                direcc = Adresses.ElementAt(0);

                // await DisplayAlert("Exito", "Latitud: "+lat+" Longitud: "+lon+Environment.NewLine+"Direccion: "+direcc, "Aceptar");

            };
            map.MapClicked += async (sender, e) => {
                var lat = e.Point.Latitude;
                var lon = e.Point.Longitude;
                IEnumerable<string> Adresses = await geo.GetAddressesForPositionAsync(new Position(lat, lon));
                direcc = Adresses.ElementAt(0);
                _pin = new Pin()
                {
                    Type = PinType.Place,
                    Label = "Lugar",
                    Address = direcc,
                    Position = new Position(e.Point.Latitude, e.Point.Longitude)
                };
                _pin.IsDraggable = true;
                map.Pins.Add(_pin);
                var res = await DisplayAlert("Ubicación Establecida", "¿Desea establecer la siguiente dirección: " + direcc + "?", "Sí", "NO");
                if (res == true)
                {

                }
                else
                {
                    map.Pins.Remove(_pin);
                    _pin = null;
                }


            };
        }
    }
}