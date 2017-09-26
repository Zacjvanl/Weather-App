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

using Syncfusion.SfChart.XForms.Droid;

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
    public class MainActivity : Activity
    {
        private Auth0Client client;
        private Button loginButton;
        private TextView userDetailsTextView;
        private TextView exampleView;
        private ApiService apiService;
        private AuthorizeState authorizeState;
        ProgressDialog progress;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            
            SetContentView(Resource.Layout.Main);

            loginButton = FindViewById<Button>(Resource.Id.LoginButton);
            loginButton.Click += LoginButtonOnClick;

            userDetailsTextView = FindViewById<TextView>(Resource.Id.UserDetailsTextView);
            userDetailsTextView.MovementMethod = new ScrollingMovementMethod();
            userDetailsTextView.Text = String.Empty;

            exampleView = FindViewById<TextView>(Resource.Id.exampleView);
            exampleView.MovementMethod = new ScrollingMovementMethod();
            exampleView.Text = String.Empty;

            client = new Auth0Client(new Auth0ClientOptions
            {
                Domain = Resources.GetString(Resource.String.auth0_domain),
                ClientId = Resources.GetString(Resource.String.auth0_client_id),
                Activity = this
            });

            getData();
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
            }
            else
            {
                sb.AppendLine($"ID Token: {loginResult.IdentityToken}");
                sb.AppendLine($"Access Token: {loginResult.AccessToken}");
                sb.AppendLine($"Refresh Token: {loginResult.RefreshToken}");

                sb.AppendLine();

                sb.AppendLine("-- Claims --");
                foreach (var claim in loginResult.User.Claims)
                {
                    sb.AppendLine($"{claim.Type} = {claim.Value}");
                }
            }

            userDetailsTextView.Text = sb.ToString();
        }

        private async void LoginButtonOnClick(object sender, EventArgs eventArgs)
        {
            userDetailsTextView.Text = "";
            progress = new ProgressDialog(this);
            progress.SetTitle("Log In");
            progress.SetMessage("Please wait while redirecting to login screen...");
            progress.SetCancelable(false); // disable dismiss by tapping outside of the dialog
            progress.Show();

            // Prepare for the login
            authorizeState = await client.PrepareLoginAsync();

            // Send the user off to the authorization endpoint
            var uri = Android.Net.Uri.Parse(authorizeState.StartUrl);
            var intent = new Intent(Intent.ActionView, uri);
            intent.AddFlags(ActivityFlags.NoHistory);
            StartActivity(intent);
        }

        public async void getData()
        {
            apiService = new ApiService();
            var sb2 = new StringBuilder();
            sb2.AppendLine();
            sb2.AppendLine("TEST DATA");
            sb2.AppendLine("---------");
            WeatherDataValuesListModel weatherDataValuesListModel = await apiService.GetData();
            try
            {
                foreach (WeatherDataValuesModel item in weatherDataValuesListModel.weatherDataValuesModel)
                {
                    if (item.Time_Stamp == new DateTime(2017, 09, 14, 00, 00, 00))
                    {
                        sb2.AppendLine("Time_Stamp: " + item.Time_Stamp);
                        sb2.AppendLine("Record: " + item.Record);
                        sb2.AppendLine("T1_Avg: " + item.T1_Avg);
                        sb2.AppendLine("T2_Avg: " + item.T2_Avg);
                        sb2.AppendLine("T1_Asp_Avg: " + item.T1_Asp_Avg);
                        sb2.AppendLine("RH1: " + item.RH1);
                        sb2.AppendLine("RH2: " + item.RH2);
                        sb2.AppendLine("U1_Avg: " + item.U1_Avg);
                        sb2.AppendLine("U2_Avg: " + item.U2_Avg);
                        sb2.AppendLine("UDir1: " + item.UDir1);
                        sb2.AppendLine("UDir2: " + item.UDir2);
                        sb2.AppendLine("U1_Max: " + item.U1_Max);
                        sb2.AppendLine("U2_Max: " + item.U2_Max);
                        sb2.AppendLine("P_mb_Avg: " + item.P_mb_Avg);
                        sb2.AppendLine("PPN_mm_Tot: " + item.PPN_mm_Tot);
                        sb2.AppendLine("TC1_Avg: " + item.TC1_Avg);
                        sb2.AppendLine("SoilW1_Avg: " + item.SoilW1_Avg);
                        sb2.AppendLine("SoilW2_Avg: " + item.SoilW2_Avg);
                        sb2.AppendLine("SoilW3_Avg: " + item.SoilW3_Avg);
                        sb2.AppendLine("SW_UP_Avg: " + item.SW_UP_Avg);
                        sb2.AppendLine("SW_Down_Avg: " + item.SW_Down_Avg);
                        sb2.AppendLine("LW_UP_Avg: " + item.LW_UP_Avg);
                        sb2.AppendLine("LW_Down_Avg: " + item.LW_Down_Avg);
                        sb2.AppendLine("CNR1TC_Avg: " + item.CNR1TC_Avg);
                        sb2.AppendLine("CNR1TK_Avg: " + item.CNR1TK_Avg);
                        sb2.AppendLine("NetSW_Avg: " + item.NetSW_Avg);
                        sb2.AppendLine("NetLW_Avg: " + item.NetLW_Avg);
                        sb2.AppendLine("Albedo_Avg: " + item.Albedo_Avg);
                        sb2.AppendLine("UpTot_Avg: " + item.UpTot_Avg);
                        sb2.AppendLine("DnTot_Avg: " + item.DnTot_Avg);
                        sb2.AppendLine("NetTot_Avg: " + item.NetTot_Avg);
                        sb2.AppendLine("CG3UpCo_Avg: " + item.CG3UpCo_Avg);
                        sb2.AppendLine("CG3DnCo_Avg: " + item.CG3DnCo_Avg);
                        sb2.AppendLine("Batt_Volt_Avg: " + item.Batt_Volt_Avg);
                        sb2.AppendLine("T_Panel_Avg: " + item.T_Panel_Avg);
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
            exampleView.Text = sb2.ToString();
        }
    }
}