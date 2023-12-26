using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;
using System.Linq;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public class PopulationGenerator : IPopulationGenerator
    {
        public (Population, Area) NewGame(string difficult, Area area)
        {
            Population population = new();
            switch (difficult)
            {
                case "Easy": population = PopulatePop(100, "Rich", area); break;
                case "Normal": population = PopulatePop(100, "Proffessionals", area); break;
                default: population = PopulatePop(100, "Poor", area); break;
            }

            return (population, area);
        }

        private Population PopulatePop(int quantity, string socialStatus, Area area)
        {
            Population pop = new();
            var parcels = area.NorthCenter.South.MicroParcels;
            int i = 0;
            while (i < quantity)
            {
                foreach (MicroParcel littleParcel in parcels)
                {
                    if (littleParcel != null)
                    {
                        littleParcel.Inhabitants += 1; i++;
                        pop = PopulationUtilities.SetCapabilities(socialStatus, littleParcel);
                        pop.Satieties = new Dictionary<MicroParcel, Dictionary<string, Dictionary<string, int>>>()
                        {
                            {littleParcel, PopulationUtilities.Satities }
                        };
                        pop.Endurances = new Dictionary<MicroParcel, Dictionary<string, int>>()
                        {
                            { littleParcel, PopulationUtilities.Endurance }
                        };
                        pop.States = new() { { littleParcel, PopulationUtilities.States } };
                        continue;
                    }
                }
            }
            return pop;
        }
    }
}
