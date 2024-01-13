using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class AridDesert : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Prairie(), new Plateau(), new Hill() };

        public ILatitude Latitude => new Subtropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Suffocating(), new Stifling() };

        public IHumidity[] Humidities => new IHumidity[] { new Barren(), new Parched() };

        public string Name =>"Arid Desert";
    }
}
