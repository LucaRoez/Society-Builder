﻿using SocietyBuilder.Models.Activity.Interfaces.IFabricationStage.IIndustrialSector;
using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.SecondarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.IIndustrialSector;

namespace SocietyBuilder.Models.Production.Manufactured.Machines
{
    public class Crane : IFabricable, ITechnologyCategory, IIndustrialSector, IMachineClassification
    {
    }
}
