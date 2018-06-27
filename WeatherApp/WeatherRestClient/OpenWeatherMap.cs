using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace WeatherApp.WeatherRestClient
{
    public class OpenWeatherMap<T>
    {
        private const string OpenWeatherApi = "http://api.openweathermap.org/data/2.5/weather?q=";
        private const string Key = "8fb5697421f6b756b61747030d67d8f8";
        HttpClient _httpClient = new HttpClient();

        public async Task<T> GetAllWeathers(string city)
        {
            var json = await _httpClient.GetStringAsync(OpenWeatherApi + city + "&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }

        private const string WeatherByIdApi = "http://api.openweathermap.org/data/2.5/group?id="; //524901,703448,2643743";

        public async Task<T> GetWeatherCityById(string id)
        {
            var json = await _httpClient.GetStringAsync(WeatherByIdApi + id + "&units=metric"+ "&APPID=" + Key);
            var getWeatherModels = JsonConvert.DeserializeObject<T>(json);
            return getWeatherModels;
        }

    }
}
