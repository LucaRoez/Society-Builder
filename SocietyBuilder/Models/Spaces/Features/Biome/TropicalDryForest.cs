using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Features.Biome
{
    public class TropicalDryForest : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Highland(), new Hill(), new Prairie(), new Plateau(), new Mountain() };

        public ILatitude Latitude => new Tropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Suffocating(), new Stifling(), new Hot(), new Warm() };

        public IHumidity[] Humidities => new IHumidity[] { new Dry(), new Withered(), new Damp(), new Parched() };

        public string Name => "Tropical Dry Forest";
    }
}
