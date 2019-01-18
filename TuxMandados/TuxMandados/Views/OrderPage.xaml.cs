using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Syncfusion.XForms.ProgressBar;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TuxMandados.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{
		public OrderPage ()
		{
			InitializeComponent ();
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