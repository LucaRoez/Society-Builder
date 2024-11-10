using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.RealEconomy
{
    public class EconomicActivityService : IEconomicActivityService
    {
        public Region CommandActivity(Region region)
        {
            foreach (Parcel? space in region.NorthCenter.South.Parcels)
            {
                if (space != null)
                {
                    foreach (Citizen citizen in space.Population)
                    {
                    }
                }
            }

            return region;
        }
    }
}
