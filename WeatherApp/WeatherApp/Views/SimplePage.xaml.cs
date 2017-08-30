using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SimplePage : ContentPage
    {
        public SimplePage()
        {
            InitializeComponent();
        }

        void Handle_Login_ClickedAsync(object sender, System.EventArgs e)
        {
            Button btncontrol = (Button)sender;
            string providername = btncontrol.Text;
            if (OAuthConfig.User == null)
            {
                Navigation.PushModalAsync(new ProviderLoginPage(providername));
                //Need to create ProviderLoginPage so follow Step 4 and Step 5 
            }




            //var authenticationResult = await OAuthAuthenticator.Authenticate(
            //    OAuthProviders.Google(
            //    "282653048569-uginrhjp00j6ti7vtl9um4nvjod7n1n8.apps.googleusercontent.com",
            //    "http://localhost"));

            //if (authenticationResult)
            //{
            //    var providerName = "Google";
            //    var accountId = authenticationResult.Account.Id;
            //    var accountDisplayName = authenticationResult.Account.DisplayName;
            //    var accessToken = authenticationResult.Account.AccessToken;
            //    await DisplayAlert("Authentication Successful", "You have changed to the User Dashboard", "OK");
            //}
            //else
            //{
            //    await DisplayAlert("Error", authenticationResult.Error, "OK");
            //}
        }
    }
}