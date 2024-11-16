using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Features.Biome
{
    public class Tundra : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Mountain(), new VeryHigh(), new ExtremelyHigh(), new Highland(), new Prairie(), new Plateau(), new Hill() };

        public ILatitude Latitude => new Polar();

        public ITemperature[] Temperatures => new ITemperature[] { new Frosty(), new Cold(), new Chilly() };

        public IHumidity[] Humidities => new IHumidity[] { new Barren(), new Parched(), new Withered() };

        public string Name => "Tundra";
    }
}
