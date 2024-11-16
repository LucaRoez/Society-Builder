using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.SecondarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;
using SocietyBuilder.Models.Production.Interfaces.IRaw.Shared;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Maritime
{
    public class SweetWater : Product, IEdible, IExtractable, IFoodSector, IEnergySector, IFoodClassification
    {
        public float DrinkingWater { get; set; }
        public float DirtyWater { get; set; }
        public float PoisonedWater { get; set; }

        public SweetWater(string name, IExcelManager excelManager)
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
