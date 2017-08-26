using WeatherApp.Views;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace WeatherApp
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            SetMainPage();
        }

        public static void SetMainPage()
        {
            Current.MainPage = new TabbedPage
            {
                Children =
                {
                    new NavigationPage(new SimplePage())
                    {
                        Title = "Simple Page",
                        Icon = Device.OnPlatform("tab_about.png", null, null)
                    },
                }
            };
        }
    }
}
