using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherApp.Services;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.Models;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserDashboard : ContentPage
    {
        private ApiService apiservice;

        private WeatherDataValuesListModel weatherData;
        public UserDashboard()
        {
            apiservice = new ApiService();

            InitializeComponent();

            ContentPage page = new ContentPage();

            AbsoluteLayout layout = new AbsoluteLayout();

            layout.Children.Add(Busy);

            page.Content = layout;

            Navigation.PushModalAsync(page);
            Task.Run(async () =>
            {
                weatherData = await apiservice.GetData();
            }).ContinueWith(t => { Navigation.PopModalAsync(); });
        }

        private async void TemperatureTrend_Clicked(object sender, EventArgs e)
        {
            try
            {
                await Navigation.PushAsync(new TabbedGraphPage("Temperature", weatherData), false);
            }
            catch(Exception exp) {
                throw exp;
            }
        }

        private async void DewPointTrend_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedGraphPage("Dew Point", weatherData));
        }

        private async void PressureTrend_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedGraphPage("Pressure", weatherData));
        }

        private  async void WindSpeedTrend_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedGraphPage("Wind Speed", weatherData));
        }

        private async void RecentPrecipitationTrend_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new TabbedGraphPage("Recent Precipitation", weatherData));
        }

        private async void AboutDepartment_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutDepartment());
        }

        private async void AboutStation_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AboutStation());
        }
    }
}