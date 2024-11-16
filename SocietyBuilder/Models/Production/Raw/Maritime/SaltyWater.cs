using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.SecondarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.Shared;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Maritime
{
    public class Saltywater : Product, IExtractable, IFoodSector, IEnergySector, IFoodClassification
    {
        public float CoastalWater { get; set; }
        public float SeaWater { get; set; }
        public float OceanWater { get; set; }
        public float DeepWater { get; set; }
        public float DirtyWater { get; set; }
        public float PoisonedWater { get; set; }

        public Saltywater(string name, IExcelManager excelManager)
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
