namespace TuxMandados.Views
{
    using Xamarin.Forms;
    using Syncfusion.XForms.ProgressBar;
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
            this.RangeColorWithGradientProgressBar.AnimationDuration = 2000;
        }
        private void RangeColorWithGradiantProgressBar_ValueChanged(object sender, ProgressValueEventArgs e)
        {
            if (e.Progress.Equals(100))
            {
                this.RangeColorWithGradientProgressBar.SetProgress(0, 0, Easing.Linear);
                
            }

            if (e.Progress.Equals(0))
            {
                this.RangeColorWithGradientProgressBar.Progress = 100;
                
            }
        }
    }
}
