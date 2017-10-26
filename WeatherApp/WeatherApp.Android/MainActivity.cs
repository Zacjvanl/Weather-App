using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Android.Text.Method;
using Android.Widget;
using Auth0.OidcClient;
using IdentityModel.OidcClient;
using System;
using System.Text;
using WeatherApp.Models;
using WeatherApp.Services;
using WeatherApp.Manager;
using WeatherApp.Views;

namespace WeatherApp.Droid
{
    [Activity(Label = "@string/app_name",
        Theme = "@style/MyTheme",
        MainLauncher = true,
        Icon = "@drawable/icon",
        LaunchMode = LaunchMode.SingleTask,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    [IntentFilter(
    new[] { Intent.ActionView },
    Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
    DataScheme = "com.companyname.weatherapp",
    DataHost = "@string/auth0_domain",
    DataPathPrefix = "/android/com.companyname.weatherapp/callback")]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsAppCompatActivity 
    {
        private Auth0Client client;
        private TextView userDetailsTextView;
        private AuthorizeState authorizeState;
        ProgressDialog progress;

        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(bundle);
            Xamarin.Forms.Forms.Init(this, bundle);

            Window.SetBackgroundDrawableResource(Resource.Drawable.dashboard);
            SetStatusBarColor(Android.Graphics.Color.Transparent);

            LoadApplication(new App());

            client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = Resources.GetString(Resource.String.auth0_domain),
                ClientId = Resources.GetString(Resource.String.auth0_client_id),
                Activity = this
            });

            userDetailsTextView = new TextView(this);

            LoginManager.Instance.PropertyChanged += async (object sender2, System.ComponentModel.PropertyChangedEventArgs e2) =>
            {
                // Prepare for the login
                userDetailsTextView.Text = "";
                progress = new ProgressDialog(this);
                progress.SetTitle("Log In");
                progress.SetMessage("Please wait while redirecting to login screen...");
                progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
                progress.Show();
                authorizeState = await client.PrepareLoginAsync();
                
                // Send the user off to the authorization endpoint
                var uri = Android.Net.Uri.Parse(authorizeState.StartUrl);
                var intent = new Intent(Intent.ActionView, uri);
                intent.AddFlags(ActivityFlags.NoHistory);

                try
                {
                    StartActivity(intent);
                }
                catch (Exception e)
                {

                }

            };

            //SetContentView(Resource.Layout.Main);

            //loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            //loginButton.Click += LoginButtonOnClick;

            //userDetailsTextView = FindViewById<TextView>(Resource.Id.UserDetailsTextView);
            //userDetailsTextView.MovementMethod = new ScrollingMovementMethod();
            //userDetailsTextView.Text = String.Empty;

            //exampleView = FindViewById<TextView>(Resource.Id.exampleView);
            //exampleView.MovementMethod = new ScrollingMovementMethod();
            //exampleView.Text = String.Empty;
            //getData();
        }

        protected override void OnResume()
        {
            base.OnResume();

            if (progress != null)
            {
                progress.Dismiss();

                progress.Dispose();
                progress = null;
            }
        }

        protected override async void OnNewIntent(Intent intent)
        {
            base.OnNewIntent(intent);

            var loginResult = await client.ProcessResponseAsync(intent.DataString, authorizeState);

            var sb = new StringBuilder();
            if (loginResult.IsError)
            {
                sb.AppendLine($"An error occurred during login: {loginResult.Error}");

                LoginManager.Instance.IsAuthenticated = false;
            }
            else
            {
                LoginManager.Instance.IsAuthenticated = true;
                //sb.AppendLine($"ID Token: {loginResult.IdentityToken}");
                //sb.AppendLine($"Access Token: {loginResult.AccessToken}");
                //sb.AppendLine($"Refresh Token: {loginResult.RefreshToken}");

                //sb.AppendLine();

                //sb.AppendLine("-- Claims --");
                //foreach (var claim in loginResult.User.Claims)
                //{
                //    sb.AppendLine($"{claim.Type} = {claim.Value}");
                //}
            }
        }

        public async void LoginButtonOnClick(object sender, EventArgs e)
        {
            userDetailsTextView.Text = "";
            progress = new ProgressDialog(this);
            progress.SetTitle("Log In");
            progress.SetMessage("Please wait while redirecting to login screen...");
            progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
            progress.Show();
        }
    }
}