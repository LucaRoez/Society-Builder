using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PopulationGenerator
{
    public interface IPopulationGenerator
    {
        Region NewGame(string difficult, Region space);
    }
}