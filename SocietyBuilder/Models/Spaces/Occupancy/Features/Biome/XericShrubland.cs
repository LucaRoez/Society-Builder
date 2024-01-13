using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class XericShrubland : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Prairie(), new Plateau(), new Hill() };

        public ILatitude Latitude => new Subtropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Stifling(), new Suffocating(), new Hot() };

        public IHumidity[] Humidities => new IHumidity[] { new Parched(), new Barren(), new Withered() };

        public string Name => "Xeric Shrubland";
    }
}
