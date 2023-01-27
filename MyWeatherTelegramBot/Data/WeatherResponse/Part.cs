using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    internal class Part
    {
        public string part_name { get; set; }
        public int temp_min { get; set; }
        public int temp_max { get; set; }
        public int temp_avg { get; set; }
        public int feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public double wind_speed { get; set; }
        public int wind_gust { get; set; }
        public string wind_dir { get; set; }
        public int pressure_mm { get; set; }
        public int pressure_pa { get; set; }
        public int humidity { get; set; }
        public int prec_mm { get; set; }
        public int prec_period { get; set; }
        public int prec_prob { get; set; }
    }
}
