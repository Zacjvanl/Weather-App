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
    public partial class UserDashboard : ContentPage
    {
        public UserDashboard()
        {
            InitializeComponent();
        }

        private void TemperatureTrend_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedGraphPage("Temperature"));
        }

        private void DewPointTrend_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedGraphPage("Dew Point"));
        }

        private void PressureTrend_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedGraphPage("Pressure"));
        }

        private void WindSpeedTrend_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedGraphPage("Wind Speed"));
        }

        private void RecentPrecipitationTrend_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new TabbedGraphPage("Recent Precipitation"));
        }
    }
}