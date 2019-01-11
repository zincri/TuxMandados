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

    public class OrdersViewModel :INotifyPropertyChanged
    {

        #region Services
        private ApiService apiService;
        private Order order;
        #endregion

        #region Atributes
        private ObservableCollection<OrderItemViewModel> _orders;
        private bool _isRefreshing;
        #endregion

        #region Constructors

        public OrdersViewModel()
        {
            this.order = new Order();
            this.apiService = new ApiService();
            this.LoadOrders();

        }
        #endregion

        #region Properties
        public ObservableCollection<OrderItemViewModel> Orders
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

            var connection = await this.apiService.CheckConnection();
            if (!connection.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", connection.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;

            }

            var response = await this.apiService.GetList<Land>("http://restcountries.eu", "/rest", "/v2/all");
            if (!response.IsSuccess)
            {
                this.IsRefreshing = false;
                await App.Current.MainPage.DisplayAlert("Error", response.Message, "Accept");
                await App.Current.MainPage.Navigation.PopAsync();
                return;
            }
            MainViewModel.GetInstance().OrdersList = (List<Land>)response.Result;
            this.IsRefreshing = false;
            this.Orders = new ObservableCollection<OrderItemViewModel>(ToOrderItemViewModel());

        }

        private IEnumerable<OrderItemViewModel> ToOrderItemViewModel()
        {
            return MainViewModel.GetInstance().OrdersList.Select(landlst => new OrderItemViewModel
            {
                Alpha2Code = landlst.Alpha2Code,
                Alpha3Code = landlst.Alpha3Code,
                AltSpellings = landlst.AltSpellings,
                Area = landlst.Area,
                Borders = landlst.Borders,
                CallingCodes = landlst.CallingCodes,
                Capital = landlst.Capital,
                Cioc = landlst.Cioc,
                Currencies = landlst.Currencies,
                Demonym = landlst.Demonym,
                Flag = landlst.Flag,
                Gini = landlst.Gini,
                Languages = landlst.Languages,
                Latlng = landlst.Latlng,
                Name = landlst.Name,
                NativeName = landlst.NativeName,
                NumericCode = landlst.NumericCode,
                Population = landlst.Population,
                Region = landlst.Region,
                RegionalBlocs = landlst.RegionalBlocs,
                Subregion = landlst.Subregion,
                Timezones = landlst.Timezones,
                TopLevelDomain = landlst.TopLevelDomain,
                Translations = landlst.Translations,
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
