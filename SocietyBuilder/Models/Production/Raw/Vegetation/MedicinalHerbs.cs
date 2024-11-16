using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IFoodSector;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Vegetation
{
    public class MedicinalHerbs : IEdible, IChemicalSector, IVegetationClassification, IAgricultureClassification
    {
        public MedicinalHerbs(string name, IExcelManager excelManager)
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
