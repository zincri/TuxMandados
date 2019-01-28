namespace TuxMandados.ViewModels
{
    using System;
    using System.ComponentModel;
    using System.Runtime.CompilerServices;
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Models;
    using TuxMandados.Views;
    using TuxMandados.Views.Repartidor;

    public class R_OrderItemViewModel : Order , INotifyPropertyChanged
    {
        #region Vars
        private string _atendidoText;
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion
        #region Constructors
        public R_OrderItemViewModel()
        {
        }
        #endregion
        #region Commands
        public ICommand SelectOrderCommand
        {
            get
            {
                return new RelayCommand(SelectOrder);
            }
        }
        public string AtendidoText
        {
            get
            {
                return _atendidoText;
            }
            set
            {
                _atendidoText = value;
                OnPropertyChanged();
            }
        }
        #endregion
        #region Methods
        private async void SelectOrder()
        {
            if (Atendido) 
            {
                await App.Current.MainPage.DisplayAlert(
                "Error",
                "Este pedido ya fue tomado por otro rapartidor. Actualiza tu lista de pedidos.",
                "Ok");
                return;
            }
            else 
            {
                MainViewModel.GetInstance().R_Order = new R_OrderViewModel(this);
                await App.Current.MainPage.Navigation.PushAsync(new R_OrderPage());
                //await App.Navigator.Navigation.PushAsync(new R_OrderPage());
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
