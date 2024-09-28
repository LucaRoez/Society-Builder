using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IGarmentSector;

namespace SocietyBuilder.Models.Production.Raw.Agricultural
{
    public class Cotton : ISpinnable, IGarmentSector, IAgricultureClassification, IVegetationClassification
    {
    }
}
