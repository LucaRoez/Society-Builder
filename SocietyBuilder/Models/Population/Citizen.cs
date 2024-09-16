using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Elements;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Population.Interfaces.IDemography;
using SocietyBuilder.Models.Population.Interfaces.ISociologic;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Citizen : IPopulation
    {
        public string Name => "Citizen";
        public Parcel Location { get; set; }
        public IClass SocialClass { get; set; }
        public IStatus SocialStatus { get; set; }
        public INiche WorkNiche { get; set; }
        public string[] States { get; set; }
        public double Capabilities { get; set; }
        public Dictionary<Necessity, AggregateDemand> Satieties { get; set; }
        public Dictionary<string, double> Endurances { get; set; }
        public double Incomes { get; set; }
        public double Capital { get; set; }

        public Citizen()
        {

        }
    }
}
