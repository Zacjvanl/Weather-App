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
    public partial class SimplePage : ContentPage
    {
        public SimplePage()
        {
            InitializeComponent();
        }

        void Handle_Login_Clicked(object sender, System.EventArgs e)
        {
            DisplayAlert("Title", "You have changed to the User Dashboard", "OK");
        }
    }
}