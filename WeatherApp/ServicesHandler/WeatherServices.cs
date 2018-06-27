using System;
using System.Threading.Tasks;
using WeatherApp.Models;
using WeatherApp.WeatherRestClient;

namespace WeatherApp.ServicesHandler
{
    public class WeatherServices
    {
        OpenWeatherMap<WeatherMainModel> _openWeatherRest = new OpenWeatherMap<WeatherMainModel>();

        public async Task<WeatherMainModel> GetWeatherDetails(string city)
        {
            var getWeatherDetails = await _openWeatherRest.GetAllWeathers(city);
            return getWeatherDetails;
        }

        OpenWeatherMap<WeatherCityModel> _OpenWeatherRest = new OpenWeatherMap<WeatherCityModel>();

        public async Task<WeatherCityModel> GetWeatherOfCity (string id)
        {
            WeatherCityModel getWeatherOfCity = await _OpenWeatherRest.GetWeatherCityById(id);
            return getWeatherOfCity;
        }
    }
}
