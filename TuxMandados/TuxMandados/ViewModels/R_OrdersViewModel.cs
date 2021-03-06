﻿using System;
namespace TuxMandados.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.ComponentModel;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Models;
    using TuxMandados.Services;
    public class R_OrdersViewModel : INotifyPropertyChanged
    {

        #region Services
        private ApiService apiService;
        private Order order;
        #endregion

        #region Atributes
        private ObservableCollection<R_OrderItemViewModel> _orders;
        private bool _isRefreshing;
        #endregion

        #region Constructors

        public R_OrdersViewModel()
        {
            this.IsRefreshing = false;
            this.order = new Order();
            this.apiService = new ApiService();
            this.LoadOrders();

        }
        #endregion

        #region Properties
        public ObservableCollection<R_OrderItemViewModel> Orders
        {
            get
            {
                return _orders;
            }
            set
            {
                _orders = value;
                OnPropertyChanged();
            }
        }

        public bool IsRefreshing
        {
            get
            {
                return _isRefreshing;
            }
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion


        #region Methods
        private async void LoadOrders()
        {

            this.IsRefreshing = true;
            //Check Connection
            /*
            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                return;

            }
            */

            var response = await this.apiService.GetList<Order>("http://restcountries.eu", "/rest", "/v2/all");

            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                return;
            }
            this.IsRefreshing = false;
            MainViewModel.GetInstance().OrdersList = (List<Order>)response.Result;
            //this.Orders = new ObservableCollection<R_OrderItemViewModel>(ToOrderItemViewModel());
            this.Orders = new ObservableCollection<R_OrderItemViewModel>(ToOrderItemViewModel().Where( l => l.Atendido==false));
        }

        private IEnumerable<R_OrderItemViewModel> ToOrderItemViewModel()
        {
            return MainViewModel.GetInstance().OrdersList.Select(lst => new R_OrderItemViewModel
            {
                Name = lst.Name,
                Hora = lst.Hora,
                Fecha = lst.Fecha,
                Atendido = lst.Atendido,
                AtendidoText = (lst.Atendido)?"Atendido" : "Sin atender",
            });

        }

        private void OnPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region Commands

        public ICommand RefreshCommand
        {
            get
            {
                return new RelayCommand(LoadOrders);
            }
        }

        #endregion
    }
}
