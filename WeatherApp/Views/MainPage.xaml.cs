using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp.Views
{
    
    public partial class MainPage : ContentPage
    {
        void Handle_ItemTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
        {
            Navigation.PushAsync(new DetailWeather(e.Item));       
        }

        public MainPage()
        {
            InitializeComponent();
        }

       
    }
}
