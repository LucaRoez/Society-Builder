using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class Taiga : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Prairie(), new Plateau(), new Hill(), new Mountain(), new VeryHigh() };

        public ILatitude Latitude => new Polar();

        public ITemperature[] Temperatures => new ITemperature[] { new Tempered(), new Cool(), new Warm(), new Chilly() };

        public IHumidity[] Humidities => new IHumidity[] { new Dry(), new Parched(), new Withered() };

        public string Name => "Taiga";
    }
}
