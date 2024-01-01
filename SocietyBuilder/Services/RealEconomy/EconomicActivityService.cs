using SocietyBuilder.Models.Population;

namespace SocietyBuilder.Services.RealEconomy
{
    public class EconomicActivityService : IEconomicActivityService
    {
        public Polis CommandActivity(Polis pop)
        {
            Array needKind = pop.Satieties.Keys.Select(need => need).ToArray();
            Array needRank = pop.Satieties.Values.Select(need => need).ToArray();
            PrioritizeNecessities((string[])needKind, ((string, int)[])needRank);
        }

        private string[] PrioritizeNecessities(string[] needKind, (string,int)[] needRank)
        {
            return needRank.OrderBy(n => n!!!)
        }
    }
}
