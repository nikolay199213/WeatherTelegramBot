using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    internal interface IWeatherClient
    {
        public Task<WeatherResponse> GetForecastByCity(City city);
    }
}
