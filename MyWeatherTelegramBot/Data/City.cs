using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }
        public string Latitude { get; set; }
        public string Longitude { get; set; }
    }
}
