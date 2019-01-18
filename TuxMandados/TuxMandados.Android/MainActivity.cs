using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace TuxMandados.Droid
{
    [Activity(Label = "TuxMandados", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjA2MTlAMzEzNjJlMzQyZTMwSDRyL0gwY29TK0doNUhpT0JwQTk2UjNvb2pYUC9OSlMvZlY3MHo1K2toOD0=");
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            Xamarin.FormsMaps.Init(this, savedInstanceState);
            Xamarin.FormsGoogleMaps.Init(this,savedInstanceState);
            LoadApplication(new App());
        }
    }
}