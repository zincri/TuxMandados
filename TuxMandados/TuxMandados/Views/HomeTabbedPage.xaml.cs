namespace TuxMandados.Views
{
    using TuxMandados.ViewModels;
    using Xamarin.Forms;
    public partial class HomeTabbedPage : TabbedPage
    {
        public HomeTabbedPage()
        {
            InitializeComponent();
            this.BarBackgroundColor = Color.FromHex("#002E6D");
            this.BarTextColor = Color.FromHex("#EFCB4B");
        }
    }
}
