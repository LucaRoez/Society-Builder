using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Features.Biome
{
    public class TreeSavanna : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Prairie(), new Plateau(), new Hill(), new Highland() };

        public ILatitude Latitude => new Subtropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Stifling(), new Hot(), new Suffocating(), new Warm() };

        public IHumidity[] Humidities => new IHumidity[] { new Withered(), new Dry(), new Damp(), new Parched() };

        public string Name => "Tree Savanna";
    }
}
