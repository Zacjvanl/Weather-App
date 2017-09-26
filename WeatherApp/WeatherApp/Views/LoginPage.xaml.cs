using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        void Handle_Login_Clicked(object sender, System.EventArgs e)
        {
        }

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}