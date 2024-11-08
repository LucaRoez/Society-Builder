using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.RealEconomy
{
    public class EconomicActivityService : IEconomicActivityService
    {
        public Area CommandActivity(Area parcel)
        {
            foreach (Parcel? space in parcel.Parcels)
            {
                if (space != null)
                {
                    foreach (Citizen citizen in space.Population)
                    {
                        citizen.Satieties = PrioritizeNecessities(citizen.Satieties, citizen.KnownPlaces);
                    }
                }
            }

            return parcel;
        }

        private List<Satiety> PrioritizeNecessities(List<Satiety> satieties, List<Parcel> knownPlaces)
        {
            foreach(Parcel possibleLocation in knownPlaces)
            {
                possibleLocation
            }
        }
    }
}
