using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace MyWeatherTelegramBot
{
    internal class YandexWeatherClient : IWeatherClient
    {
        private readonly string _baseUrl;
        private readonly string _apiKey;
        public YandexWeatherClient(string baseUrl, string apiKey)
        {
            _baseUrl = baseUrl;
            _apiKey = apiKey;
        }

        public async Task<WeatherResponse> GetForecastByCity(City city)
        {
            var url = $"{_baseUrl}lat={city.Latitude}&lon={city.Longitude}&lang=ru_RU";
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("X-Yandex-API-Key", _apiKey);
            var response = await httpClient.GetAsync(url);
            var forecast = await response.Content.ReadAsStringAsync();
            WeatherResponse? weatherForecast = JsonSerializer.Deserialize<WeatherResponse>(forecast);
            return weatherForecast;
        }
    }
}
