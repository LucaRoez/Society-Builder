using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.Shared;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Maritime
{
    public class HydraulicForce : Product, IExtractable, IEnergySector, IMaritimeClassification
    {
        public float CurrentSource { get; set; } // some could be through currents (the use of rivers, seas, oceans or even artificial streams)
        public float TidalSource { get; set; } // some could be through tides (similar to pump use)
        public bool IsDamSource { get; set; } // if not dam then is through streams
        public bool IsPumpSource { get; set; } // if not pump then is with nature
        public bool IsOffShoreSource { get; set; } // if not off-shore then it's on-shore
        public HydraulicForce(string name, IExcelManager excelManager)
            : base(name, excelManager)
        {
        }

        public override Product ReturnProduct(int quantity)
        {
            throw new NotImplementedException();
        }

        public override List<Product> ReturnWaste()
        {
            throw new NotImplementedException();
        }
    }
}
