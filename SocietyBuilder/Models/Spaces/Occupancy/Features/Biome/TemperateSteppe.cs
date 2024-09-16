using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class TemperateSteppe : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Prairie(), new Plateau(), new Hill() };

        public ILatitude Latitude => new SubPolar();

        public ITemperature[] Temperatures => new ITemperature[] { new Tempered(), new Cool(), new Chilly(), new Warm() };

        public IHumidity[] Humidities => new IHumidity[] { new Damp(), new Moist(), new Dry(), new Humid() };

        public string Name => "Temperate Steppe";
    }
}
