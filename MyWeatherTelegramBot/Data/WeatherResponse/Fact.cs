﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    internal class Fact
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public string icon { get; set; }
        public string condition { get; set; }
        public double wind_speed { get; set; }
        public double wind_gust { get; set; }
        public string wind_dir { get; set; }
        public double pressure_mm { get; set; }
        public double pressure_pa { get; set; }
        public double humidity { get; set; }
        public string daytime { get; set; }
        public bool polar { get; set; }
        public string season { get; set; }
        public double obs_time { get; set; }
    }
}
