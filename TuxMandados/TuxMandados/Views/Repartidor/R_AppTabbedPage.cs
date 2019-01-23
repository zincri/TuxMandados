namespace TuxMandados.Views.Repartidor
{
    using TuxMandados.ViewModels;
    using Xamarin.Forms;
    public class R_AppTabbedPage : TabbedPage
    {
        public R_AppTabbedPage()
        {
            this.BarBackgroundColor = Color.FromHex("#33CAFF");
            this.BarTextColor = Color.FromHex("#000000");
            var mainViewModel = MainViewModel.GetInstance();
            //mainViewModel.Home = new HomeViewModel();
            mainViewModel.R_Orders = new R_OrdersViewModel();
            mainViewModel.R_Orders.IsRefreshing = false;
            //mainViewModel.About = new AboutViewModel();

            Children.Add(new R_HomePage() { Icon = "homeworld.png", Title = "Inicio" });
            Children.Add(new R_OrdersPage() { Icon = "orders.png", Title = "Pedidos" });
            Children.Add(new R_MenuPage() { Icon = "ic_settings.png", Title = "General" });
        }
    }
}

