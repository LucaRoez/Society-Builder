using SocietyBuilder.Models.Population.Interfaces;

namespace SocietyBuilder.Models.Population.Features
{
    public class Illness : ICondition
    {
        public string Name { get; set; } = string.Empty;

    }
}
