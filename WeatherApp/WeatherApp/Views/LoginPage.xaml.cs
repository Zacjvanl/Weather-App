using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.Manager;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public void LoginButtonOnClick(object sender, System.EventArgs e)
        {
            LoginManager.Instance.Login();
        }

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}