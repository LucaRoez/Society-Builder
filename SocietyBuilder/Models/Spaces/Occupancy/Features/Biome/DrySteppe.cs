using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class DrySteppe : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Prairie(), new Plateau(), new Hill() };

        public ILatitude Latitude => new SubPolar();

        public ITemperature[] Temperatures => new ITemperature[] { new Chilly(), new Cool(), new Cold(), new Tempered() };

        public IHumidity[] Humidities => new IHumidity[] { new Dry(), new Withered(), new Parched(), new Damp() };

        public string Name => "Dry Steppe";
    }
}
