using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using WeatherApp.Models;

using WeatherApp.Services;

namespace WeatherApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class TabbedGraphPage : TabbedPage
    {

        public TabbedGraphPage(string GraphTitle, WeatherDataValuesListModel Data)
        {
            Graph graphData = new Graph(GraphTitle);

            Title = GraphTitle + " Trends";

            this.Children.Add(new GraphPage(graphData.Hourly(Data), "Hourly"));
            this.Children.Add(new GraphPage(graphData.Daily(Data), "Daily"));
            this.Children.Add(new GraphPage(graphData.Weekly(Data), "Weekly"));

            InitializeComponent();
        }
    }
}