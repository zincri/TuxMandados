

namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Views;
    public class HomeViewModel : INotifyPropertyChanged
    {
        #region Vars  
        private bool _isEnable;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion

        #region Properties
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
        #endregion
        #region Constructors
        public HomeViewModel()
        {
        }
        #endregion

        #region Commands

        public ICommand TuxMandarCommand
        {
            get
            {
                return new RelayCommand(TuxMandarMethod);
            }
        }

        #endregion



        #region Methods

        private async void TuxMandarMethod()
        {
            //await App.Current.MainPage.DisplayAlert("Correcto","Tuxmandado","ok");
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.NewOrder = new NewOrderViewModel();
            await App.Current.MainPage.Navigation.PushAsync(new NewOrderPage());

            //await App.Navigator.Navigation.PushAsync(new NewOrderPage());
            //Despues de lanzar el nuevo mandado y se mande el mantado a un tuxmandadero
            //se puede poner aqui abajo una seccion de codigo donde verifique el await de
            //aqui arriba una vez lanzado y terminado el pedido, se habilitara un boton de
            //ver "detalle del mandado" o se lanzara una actividad que solo tenga ese boton,
            // o bien redirigir a otra vista donde solo este el detalle del pedido.

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
