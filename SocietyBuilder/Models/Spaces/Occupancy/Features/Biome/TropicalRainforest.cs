using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class TropicalRainforest : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Plateau(), new Hill(), new Prairie(), new Highland(), new Mountain() };

        public ILatitude Latitude => new Tropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Stifling(), new Suffocating(), new Hot(), new Warm() };

        public IHumidity[] Humidities => new IHumidity[] { new Dank(), new Humid(), new Moist() };

        public string Name => "Tropical Rainforest";
    }
}
