using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Population : IPopulation
    {
        public Dictionary<MicroParcel, string[]> States { get; set; }
        public Dictionary<MicroParcel, int> Capabilities { get; set; }
        public Dictionary<MicroParcel, Dictionary<string, int>> Satieties { get; set; }
        public Dictionary<MicroParcel, Dictionary<string, int>> Endurances { get; set; }
        public Dictionary<MicroParcel, Dictionary<int, Dictionary<IActivity, int>>> Incomes { get; set; }

        public Population()
        {

        }
    }
}
