using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.Core;
using Syncfusion.SfChart;
using System.Collections.ObjectModel;
using Syncfusion.SfChart.XForms;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        public GraphPage(ObservableCollection<ChartDataPoint> GraphData, string Type)
        {
            this.Title = Type;

            InitializeComponent();
            Data.ItemsSource = GraphData;


            Parallel.Invoke(async () => { var taskDelay = Task.Delay(750); await Task.WhenAll(taskDelay); await Chart1.FadeTo(0.6, 1500, Easing.CubicOut); }, () => Chart1.TranslateTo(0, 10, 1800, Easing.CubicOut));
        }
    }
}