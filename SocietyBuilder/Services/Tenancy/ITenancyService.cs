using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Population.Interfaces;
using SocietyBuilder.Models.Spaces;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Services.Tenancy
{
    public interface ITenancyService
    {
        Area Inhabit(Area area);
    }
}