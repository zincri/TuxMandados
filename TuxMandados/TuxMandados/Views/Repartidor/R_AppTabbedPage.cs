namespace TuxMandados.Views.Repartidor
{
    using TuxMandados.ViewModels;
    using Xamarin.Forms;
    public class R_AppTabbedPage : TabbedPage
    {
        public R_AppTabbedPage()
        {
            this.BarBackgroundColor = Color.FromHex("#33CAFF");
            this.BarTextColor = Color.FromHex("#EFCB4B");
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Home = new HomeViewModel();
            mainViewModel.Orders = new OrdersViewModel();
            mainViewModel.Orders.IsRefreshing = false;
            mainViewModel.About = new AboutViewModel();

            Children.Add(new HomePage() { Icon = "homeworld.png", Title = "Inicio" });
            Children.Add(new OrdersPage() { Icon = "orders.png", Title = "Pedidos" });
            Children.Add(new AboutPage() { Icon = "info.png", Title = "Nosotros" });
            Children.Add(new MenuPage() { Icon = "profile.png", Title = "General" });
        }
    }
}

