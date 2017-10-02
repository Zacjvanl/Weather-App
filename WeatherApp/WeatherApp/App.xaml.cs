using WeatherApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WeatherApp.Models;
using System.Threading.Tasks;
using Syncfusion.SfBusyIndicator.XForms;
using WeatherApp.Services;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new UserDashboard())
            {
                BarBackgroundColor = Color.DarkBlue,
            };
        }
    }
}
