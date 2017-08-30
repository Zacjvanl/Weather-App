using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace WeatherApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProviderLoginPage : ContentPage
    {
        public string providerName { get; set; }

        public ProviderLoginPage(string providername)
        {
            InitializeComponent();
            providerName = providername;
        }
    }
}