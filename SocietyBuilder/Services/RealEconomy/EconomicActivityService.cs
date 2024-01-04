using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Elements;

namespace SocietyBuilder.Services.RealEconomy
{
    public class EconomicActivityService : IEconomicActivityService
    {
        public Citizen CommandActivity(Citizen citizen)
        {
            citizen.Satieties = PrioritizeNecessities(citizen.Satieties);
            citizen.WorkNiche = SetActivity(citizen);
        }

        private Dictionary<Necessity, AggregateDemand> PrioritizeNecessities(Dictionary<Necessity, AggregateDemand> needKinds)
        {
            var orderedNeeds = needKinds
                .OrderBy(nk => nk.Key.Priority)
                .ThenByDescending(nk => nk.Value.Level)
                .ThenByDescending(nk => nk.Value.Level + 1 == needKinds.Values.Max(ad => ad.Level))
                .ToDictionary(pair => pair.Key, pair => pair.Value);

            return orderedNeeds;
        }

        private void SetActivity(Citizen citizen)
        {
            KeyValuePair<Necessity, AggregateDemand> needToSatisfy = citizen.Satieties.FirstOrDefault();
            citizen.WorkNiche = ActivityUtilities.SearchActivity(needToSatisfy);
        }
    }
}
