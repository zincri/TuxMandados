﻿

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
        private string _nombre;
        private string _apePat;
        private string _apeMat;
        public event PropertyChangedEventHandler PropertyChanged;
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
            this.Nombre = "Anonimo";

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
