using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IEnergySector;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;

namespace SocietyBuilder.Models.Production.Raw.Livestock
{
    public class EquineCattle : IEdible, ILively, IFoodSector, IEnergySector, ILivestockClassification
    {
    }
}
