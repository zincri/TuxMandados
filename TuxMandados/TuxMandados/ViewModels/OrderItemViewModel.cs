namespace TuxMandados.ViewModels
{
    using System.Windows.Input;
    using GalaSoft.MvvmLight.Command;
    using TuxMandados.Models;
    using TuxMandados.Views;
    public class OrderItemViewModel : Order
    {
        public OrderItemViewModel()
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
            MainViewModel.GetInstance().Order = new OrderViewModel(this);
            await App.Current.MainPage.Navigation.PushAsync(new OrderPage());
        }
        #endregion
    }
}
