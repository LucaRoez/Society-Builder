using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Services.Tenancy
{
    public class TenancyService : ITenancyService
    {
        public (Area, Population) Inhabit(Population population, Area area)
        {
            (Area, Population) start = Inhabit(population, area);

            return start;
        }
    }
}
