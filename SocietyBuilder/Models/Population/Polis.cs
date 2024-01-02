using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Models.Population
{
    public class Polis : IPopulation
    {
        public string Name => "Population";
        public Dictionary<MicroParcel, Citizen> Population { get; set; }
    }
}
