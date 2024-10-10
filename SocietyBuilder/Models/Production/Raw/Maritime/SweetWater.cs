using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.SecondarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;
using SocietyBuilder.Models.Production.Interfaces.IRaw.Shared;

namespace SocietyBuilder.Models.Production.Raw.Maritime
{
    public class SweetWater : IEdible, IExtractable, IFoodSector, IEnergySector, IFoodClassification
    {
    }
}
