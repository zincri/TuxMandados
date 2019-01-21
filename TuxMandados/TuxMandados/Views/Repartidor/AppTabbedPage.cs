using System;

using Xamarin.Forms;

namespace TuxMandados.Views.Repartidor
{
    public class AppTabbedPage : ContentPage
    {
        public AppTabbedPage()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

