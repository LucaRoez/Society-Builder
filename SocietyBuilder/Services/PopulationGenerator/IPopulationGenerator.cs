using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public interface IPopulationGenerator
    {
        (Population, Area) NewGame(string difficult, Area space);
    }
}