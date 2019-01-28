namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Models;
    public class R_OrderViewModel
    {
        #region Vars
        private bool _isEnable;
        private bool _isRunning;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Properties
        public Order Order
        {
            get;
            set;
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
       

        // Create the OnPropertyChanged method to raise the event

        #endregion

        #region Commands
        public ICommand IgnoreCommand
        {
            get 
            {
                return new RelayCommand(IgnorarMethod);
            }
        }
        public ICommand AcceptCommand
        {
            get
            {
                return new RelayCommand(AceptarMethod);
            }
        }
        #endregion

        #region Constructors
        public R_OrderViewModel(Order order)
        {
            IsEnable = true;
            IsRunning = false;
            this.Order = order;
        }
        #endregion

        #region Methods
        private async void AceptarMethod()
        {
            this.IsEnable = false;
            this.Order.Atendido = true;
            await App.Current.MainPage.DisplayAlert(
            "Mensaje",
            "El pedido fue aceptado!",
            "Ok");
            // {Binding IsEnable, Mode=TwoWay}

            //Aqui consumira un servicio que le indicara si el pedido esta disponible,
            //en caso de ser así, el pedido se le asignara al repartidor que hizo
            //la peticion antes que cualquier otro, despues la aplicacion mostrara un modal
            //El modal mostrara las opciones de "ver detalle" y "salir"

        }
        private async void IgnorarMethod()
        {
            this.IsRunning = true;
            this.IsEnable = false;
            await App.Current.MainPage.DisplayAlert(
            "Mensaje",
            "El pedido fue ignorado!",
            "Ok");
            this.IsRunning = false;
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
