using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IEnergySector;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Vegetation
{
    public class Reforestation : Product, ILively, IConstructionSector, IIndustrialSector
    {
        public float Trees { get; set; }
        public float Vegetation { get; set; }

        public Reforestation(string name, IExcelManager excelManager)
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
