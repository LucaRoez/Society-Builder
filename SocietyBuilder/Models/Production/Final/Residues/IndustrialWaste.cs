using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.SecondarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using IDisposable = SocietyBuilder.Models.Production.Interfaces.IFinal.ISocialSector.IDisposable;

namespace SocietyBuilder.Models.Production.Final.Residues
{
    public class IndustrialWaste : IDisposable, IWasteSector, IResidueClassification
    {
    }
}
