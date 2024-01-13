using SocietyBuilder.Models.Spaces.Altitude;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Latitude;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;
using SocietyBuilder.Models.Spaces.Wheather;

namespace SocietyBuilder.Models.Spaces.Occupancy.Features.Biome
{
    public class SubtropicalDryForest : IBiome
    {
        public IAltitude[] Altitudes => new IAltitude[] { new Hill(), new Plateau(), new Prairie(), new Mountain() };

        public ILatitude Latitude => new Subtropical();

        public ITemperature[] Temperatures => new ITemperature[] { new Hot(), new Warm(), new Stifling(), new Templated() };

        public IHumidity[] Humidities => new IHumidity[] { new Damp(), new Dry(), new Moist(), new Withered() };

        public string Name => "Subtropical Dry Forest";
    }
}
