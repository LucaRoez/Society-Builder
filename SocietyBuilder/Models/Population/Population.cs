using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Population : IPopulation
    {
        public Dictionary<MicroParcel, string[]> States { get; set; }
        public Dictionary<MicroParcel, int> Capabilities { get; set; }
        public Dictionary<MicroParcel, Dictionary<string, Dictionary<string, int>>> Satieties { get; set; }
        public Dictionary<MicroParcel, Dictionary<string, int>> Endurances { get; set; }
                                                // Sector   // Social Class // Income per class of sector
        public Dictionary<MicroParcel, Dictionary<IActivity, Dictionary<string, int>>> Incomes { get; set; }

        public Population()
        {

        }
    }
}
