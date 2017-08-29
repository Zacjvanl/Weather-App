using Android.App;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms.Platform.Android;

namespace WeatherApp.Droid
{
    [Activity(Label = "@string/app_name", Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                // Kill status bar underlay added by FormsAppCompatActivity
                // Must be done before calling FormsAppCompatActivity.OnCreate()
                var statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                if (statusBarHeightInfo == null)
                {
                    statusBarHeightInfo = typeof(FormsAppCompatActivity).GetField("_statusBarHeight", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic);
                }
                statusBarHeightInfo?.SetValue(this, 0);
            }

            base.OnCreate(bundle);

            this.Window.AddFlags(Android.Views.WindowManagerFlags.Fullscreen | Android.Views.WindowManagerFlags.TurnScreenOn);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            LoadApplication(new App());
        }
    }
}