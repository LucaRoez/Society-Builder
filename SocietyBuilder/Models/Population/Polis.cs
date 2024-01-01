using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Population.Interfaces.ISociologic;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Polis : IPopulation
    {
        public string Name => "";
        public MicroParcel Location { get; set; }
        public IClass SocialClass { get; set; }
        public IStatus SocialStatus { get; set; }
        public string[] States { get; set; }
        public double Capabilities { get; set; }
        public Dictionary<string, (string, int)> Satieties { get; set; }
        public Dictionary<string, int> Endurances { get; set; }
                        // Sector   // Social Class // Income per class of sector
        public Dictionary<IActivity, (IClass, double)> Incomes { get; set; }
        public double Capital { get; set; }

        public Polis()
        {

        }
    }
}
