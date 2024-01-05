using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.RealEconomy
{
    public interface IEconomicActivityService
    {
        Parcel CommandActivity(Parcel parcel);
    }
}