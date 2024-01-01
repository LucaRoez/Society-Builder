using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public interface IPopulationGenerator
    {
        Area NewGame(string difficult, Area space);
    }
}