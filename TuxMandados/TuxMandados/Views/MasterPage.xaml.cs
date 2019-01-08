using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace TuxMandados.Views
{
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
            App.Navigator = Navigator;
        }
    }
}
