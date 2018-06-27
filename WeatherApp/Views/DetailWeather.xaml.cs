using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace WeatherApp.Views
{
    public partial class DetailWeather : ContentPage
    {
        public DetailWeather(object v)
        {
            InitializeComponent();
            var x = (Models.List)v;
            if (!String.IsNullOrEmpty(x.Name))
                lblVisible.Text = x.Name;
        }
    }
}
