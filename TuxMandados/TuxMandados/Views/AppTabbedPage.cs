namespace TuxMandados.Views
{
    using Xamarin.Forms;
    using TuxMandados.ViewModels;
    public class AppTabbedPage : TabbedPage
    {
        
        public AppTabbedPage()
        {
            this.BarBackgroundColor = Color.FromHex("#002E6D");
            this.BarTextColor = Color.FromHex("#EFCB4B");
            var mainViewModel = MainViewModel.GetInstance();
            mainViewModel.Home = new HomeViewModel();
            mainViewModel.Orders = new OrdersViewModel();
            mainViewModel.Orders.IsRefreshing = false;
           
            mainViewModel.About = new AboutViewModel();

            Children.Add(new HomePage() { Icon = "homeworld.png", Title = "Inicio" });
            Children.Add(new OrdersPage() { Icon = "orders.png", Title = "Pedidos" });
            Children.Add(new AboutPage() { Icon = "info.png", Title = "Nosotros" });
            Children.Add(new MenuPage() { Icon = "ic_settings.png", Title = "General" });
        }
    }
}

