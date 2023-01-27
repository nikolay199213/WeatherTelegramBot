using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    internal class WeatherResponse
    {
        public int now { get; set; }
        public DateTime now_dt { get; set; }
        public Info info { get; set; }
        public Fact fact { get; set; }
        public Forecast forecast { get; set; }
    }
}
