using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class SubtropicalRainforest : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Plateau(), new Hill(), new Prairie(), new Mountain() };

        public ILatitude Latitude => new Subtropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Hot(), new Stifling(), new Warm(), new Tempered() };

        public IHumidity[] Humidities => new IHumidity[] { new Humid(), new Dank(), new Moist() };

        public string Name => "Subtropical Rainforest";
    }
}
