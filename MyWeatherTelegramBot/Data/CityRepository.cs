using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyWeatherTelegramBot
{
    public class CityRepository
    {
        private GeographyContext context;
        public CityRepository(GeographyContext context)
        {
            this.context = context;
        }
        public City GetСoordinatesByName(string name)
        {
            return context.Cities.Where(x => x.Name == name).FirstOrDefault();
            
        }
    }
}
