using System.ComponentModel;
using WeatherApp.Models;
using WeatherApp.Views;
using WeatherApp.Services;
using System.Runtime.CompilerServices;
using Xamarin.Forms;
using System.Threading.Tasks;

namespace WeatherApp.Manager
{
    public sealed class LoginManager : INotifyPropertyChanged
    {
        static readonly LoginManager _instance = new LoginManager();
        private bool isAuthenticated;
        private ApiService apiservice = new ApiService();
        private WeatherDataValuesListModel weatherData;

        public bool IsAuthenticated {
            get { return isAuthenticated; }
            set
            {
                this.isAuthenticated = value;

                LoginCallback();
            }
        }

        public WeatherDataValuesListModel WeatherData
        {
            get { return weatherData; }
            set { weatherData = value; }
        }

        public static LoginManager Instance
        {
            get { return _instance; }
        }

        public void Login()
        {
            OnPropertyChanged();
        }

        protected void LoginCallback()
        {
            if (isAuthenticated)
            {
                App.Current.MainPage.Navigation.PushAsync(new UserDashboard());

                App.Current.MainPage.Navigation.PushModalAsync(new LoadingPage());
            }
            else
            {
                //Say something about failure to authenticate
            }
        }

        //public global::IdentityModel.OidcClient.AuthorizeState PropertyChange { get; set; }

        private LoginManager()
        {
            //Whatever...
        }

        public void Initialize()
        {

        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            if (PropertyChanged == null)
            {
                return;
            }
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        protected void OnPropertyChanged (PropertyChangedEventArgs e)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
                handler(this, e);
        }
    }
}
