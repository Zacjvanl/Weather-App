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


            Parallel.Invoke(async () => {
                                var taskDelay = Task.Delay(750);
                                await Task.WhenAll(taskDelay);
                                await DataChart.FadeTo(0.6, 1500, Easing.CubicOut);
                            },
                            async () => {
                                await btn1.FadeTo(1, 1000, Easing.CubicOut);
                                await btn2.FadeTo(1, 1000, Easing.CubicOut);
                                await btn3.FadeTo(1, 1000, Easing.CubicOut);
                            }, 
                            async () => {
                                await btn1.TranslateTo(0, 0, 1000, Easing.CubicOut);
                                await btn2.TranslateTo(0, 0, 1000, Easing.CubicOut);
                                await btn3.TranslateTo(0, 0, 1000, Easing.CubicOut);
                            },
                            () => DataChart.TranslateTo(0, 10, 1800, Easing.CubicOut)
             );
        }
    }
}