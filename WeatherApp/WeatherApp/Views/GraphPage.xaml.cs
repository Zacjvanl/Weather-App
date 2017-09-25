using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Syncfusion.Core;
using Syncfusion.SfChart;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GraphPage : ContentPage
    {
        public GraphPage()
        {
            InitializeComponent();

            Parallel.Invoke(async () => { var taskDelay = Task.Delay(750); await Task.WhenAll(taskDelay); await Chart1.FadeTo(0.6, 1500, Easing.CubicOut); }, () => Chart1.TranslateTo(0, 0, 1800, Easing.CubicOut));

            //this.Content = Graph();
        }

        private StackLayout Graph()
        {
            StackLayout graphArea = new StackLayout()
            {
                VerticalOptions = LayoutOptions.Fill,
                HorizontalOptions = LayoutOptions.Fill,
                BackgroundColor = Color.Gray,
            };
            graphArea.Children.Add(CreateGraph());

            return graphArea;
        }

        private WebView CreateGraph()
        {
            HtmlWebViewSource PlotlyGraph = new HtmlWebViewSource();
            Models.Graph graph = new Models.Graph();
            PlotlyGraph.Html = graph.test;

            return new WebView
            {
                Source = PlotlyGraph,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
        }
    }
}