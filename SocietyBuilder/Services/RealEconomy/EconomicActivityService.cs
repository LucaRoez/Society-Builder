using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Elements;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.RealEconomy
{
    public class EconomicActivityService : IEconomicActivityService
    {
        public Parcel CommandActivity(Parcel parcel)
        {
            foreach (MicroParcel space in parcel.MicroParcels)
            {
                if (space != null)
                {
                    foreach (Citizen citizen in space.Population)
                    {
                        citizen.Satieties = PrioritizeNecessities(citizen.Satieties);
                        citizen.WorkNiche = SetActivity(citizen.Satieties.FirstOrDefault());
                        citizen.Incomes = DoActivity(citizen.WorkNiche, space.Resources);
                    }
                }
            }

            return parcel;
        }

        private Dictionary<Necessity, AggregateDemand> PrioritizeNecessities(Dictionary<Necessity, AggregateDemand> needKinds) => needKinds
                .OrderBy(nk => nk.Key.Priority)
                .ThenByDescending(nk => nk.Value.Level)
                .ThenByDescending(nk => nk.Value.Level + 1 == needKinds.Values.Max(ad => ad.Level))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

        private INiche SetActivity(KeyValuePair<Necessity, AggregateDemand> needToSatisfy) => ActivityUtilities.SearchActivity(needToSatisfy);

        private double DoActivity(INiche workNiche, Dictionary<string, double> resources)
        {
            throw new NotImplementedException();
        }
    }
}
