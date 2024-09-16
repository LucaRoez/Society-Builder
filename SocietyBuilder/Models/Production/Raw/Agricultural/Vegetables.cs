using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;

namespace SocietyBuilder.Models.Production.Raw.Agricultural
{
    public class Vegetables : IEdible, IFoodSector, IAgriculture, IVegetation
    {
    }
}
