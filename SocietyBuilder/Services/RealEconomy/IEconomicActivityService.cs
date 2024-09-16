using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.RealEconomy
{
    public interface IEconomicActivityService
    {
        Area CommandActivity(Area parcel);
    }
}