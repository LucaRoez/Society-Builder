using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IGarmentSector;

namespace SocietyBuilder.Models.Production.Raw.Livestock
{
    public class SheepCattle : IEdible, ISpinnable, IFoodSector, IGarmentSector, ILivestock
    {
    }
}
