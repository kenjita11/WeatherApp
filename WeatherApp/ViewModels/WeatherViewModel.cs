using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Input;
using WeatherApp.Models;
using WeatherApp.ServicesHandler;
using Xamarin.Forms;

namespace WeatherApp.ViewModels
{
   
    public class WeatherViewModel : INotifyPropertyChanged
    {
        private WeatherCityModel _listCity;
        public WeatherCityModel ListCity
        {
            get { return _listCity; }
            set
            {
                _listCity = value;
                //IconImageString = "http://openweathermap.org/img/w/" + _listCity.weather[0].icon + ".png";
                OnPropertyChanged();
            }
        }
        public WeatherViewModel()
        {
            InitializeGetWeatherById();
        }
        // search in listview
        public void search()
        {
            string character = _search;
            //get text from entry 
            //call list
            // so sanh
            // return list
        }
        
        private string _search;
        public string Search
        {
            get { return _search; }
            set
            {
                _search = value;
                search();
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        WeatherServices _weatherServices = new WeatherServices();

        // convert F => C
        static double Celcius(double f)
        {
            double  c = f/10;
            return c;
        }
        static double CelciusCtoF(int c)
        {
            double f = c * 1.8 + 32;
            return f;
        }
        private WeatherMainModel _weatherMainModel;  // for xaml binding
        public WeatherMainModel WeatherMainModel
        {
            get { return _weatherMainModel; }
            set
            {
                _weatherMainModel = value;
                IconImageString = "http://openweathermap.org/img/w/" + _weatherMainModel.weather[0].icon + ".png";
                CelciusC = (int)Celcius(double.Parse(_weatherMainModel.main.temp));
                CelciusF = (int)CelciusCtoF(CelciusC);
                OnPropertyChanged();
            }
        }
        private int _celciusF;
        public int CelciusF
        {
            get { return _celciusF; }
            set
            {
                _celciusF = value;
                OnPropertyChanged();
            }
        }

        private int _celciusC;
        public int CelciusC
        {
            get { return _celciusC; }
            set
            {
                _celciusC = value;
                OnPropertyChanged();
            }
        }

        private string _iconImageString;
        public string IconImageString
        {
            get { return _iconImageString; }
            set
            {
                _iconImageString = value;
                OnPropertyChanged();
            }
        }

        private string _itemSelected;
        public string ItemSelected
        {
            get { return _itemSelected; }
            set
            {
                _itemSelected = value;
                OnPropertyChanged();
            }
        }

        private string _city;
        public string City
        {
            get { return _city; }
            set
            {
                _city = value;
                Task.Run(async () => {await InitializeGetWeatherAsync();});
                OnPropertyChanged();
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get { return _isBusy; }
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        private async Task InitializeGetWeatherAsync()
        {
            try
            {
                IsBusy = true; 
                WeatherMainModel = await _weatherServices.GetWeatherDetails(_city);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private async Task InitializeGetWeatherById()
        {
            try
            {
                IsBusy = true;
                ListCity = await _weatherServices.GetWeatherOfCity("524901,703448,264374");
            }
            finally
            {
                IsBusy = false;
            }

        }

    }
}
