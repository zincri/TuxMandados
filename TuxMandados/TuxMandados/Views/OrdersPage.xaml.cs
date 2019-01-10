namespace TuxMandados.Views
{
    using TuxMandados.ViewModels;
    using Xamarin.Forms;
    public partial class OrdersPage : ContentPage
    {
        public OrdersPage()
        {
            InitializeComponent();
            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Token = token;
            mainViewModel.Orders = new OrdersViewModel();
        }
    }
}
