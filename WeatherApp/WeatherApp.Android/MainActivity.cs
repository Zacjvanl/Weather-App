using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace WeatherApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Window.SetBackgroundDrawableResource(Resource.Drawable.dashboard);
            SetStatusBarColor(Android.Graphics.Color.Transparent);

            LoadApplication(new App());
        }
    }
}