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
    public partial class LoginPage : ContentPage
    {
        void Handle_Login_Clicked(object sender, System.EventArgs e)
        {
            App.Current.MainPage = new UserDashboard();
        }

        public LoginPage()
        {
            InitializeComponent();
        }
    }
}