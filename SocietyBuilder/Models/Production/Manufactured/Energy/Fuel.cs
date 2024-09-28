using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.SecondarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.IEnergySector;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.Shared;

namespace SocietyBuilder.Models.Production.Manufactured.Energy
{
    public class Fuel : IProcessed, IEnergy, IEnergySector, IPowerClassification
    {
    }
}
