namespace TuxMandados.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Models;
    using TuxMandados.Views;
    using TuxMandados.Views.Repartidor;

    public class R_OrderItemViewModel : Order
    {
        public R_OrderItemViewModel()
        {
        }
        #region Commands
        public ICommand SelectOrderCommand
        {
            get
            {
                return new RelayCommand(SelectOrder);
            }
        }
        #endregion
        #region Methods
        private async void SelectOrder()
        {
            MainViewModel.GetInstance().R_Order = new R_OrderViewModel(this);
            await App.Current.MainPage.Navigation.PushAsync(new R_OrderPage());
        }
        #endregion
    }
}
