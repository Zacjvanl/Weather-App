using Syncfusion.SfChart.XForms.UWP;

namespace WeatherApp.UWP
{
    public sealed partial class MainPage
    {
        public MainPage()
        {
            this.InitializeComponent();

            new SfChartRenderer();

            LoadApplication(new WeatherApp.App());
        }
    }
}