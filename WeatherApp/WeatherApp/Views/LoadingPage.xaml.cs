using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using WeatherApp.Services;
using WeatherApp.Models;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoadingPage : ContentPage
    {
        private ApiService apiservice;

        private WeatherDataValuesListModel weatherData;
        public LoadingPage()
        {
            apiservice = new ApiService();
            InitializeComponent();

            Task.Run(async () =>
            {
                weatherData = await apiservice.GetData();
            }).ContinueWith(t => { Navigation.PopModalAsync(); Navigation.PushAsync(new LoginPage()); });
        }
    }
}