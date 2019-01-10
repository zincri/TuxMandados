

using Foundation;
using UIKit;
using Xamarin.Forms.GoogleMaps.iOS;
namespace TuxMandados.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            Xamarin.FormsMaps.Init();
            Xamarin.FormsGoogleMaps.Init("AIzaSyCUuG9Ir8lXLITRga9G93Z286WyruRmJDc");
            //bool flag = Xamarin.FormsGoogleMaps.IsInitialized;
            LoadApplication(new App());

            //Xamarin.FormsMaps.Init();
            return base.FinishedLaunching(app, options);
        }
    }
}
