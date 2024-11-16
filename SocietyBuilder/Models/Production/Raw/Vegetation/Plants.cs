using SocietyBuilder.Models.Activity.Interfaces.SectorClassification.PrimarySector;
using SocietyBuilder.Models.Activity.Interfaces.Sectors;
using SocietyBuilder.Models.Production.Interfaces.IRaw.IEnergySector;
using SocietyBuilder.Models.Production.Raw.Agricultural;
using SocietyBuilder.Services.UniversalServices;

namespace SocietyBuilder.Models.Production.Raw.Vegetation
{
    public class Plants : Product, ILively, IFoodSector, IVegetationClassification, IAgricultureClassification
    {
        public float Trees { get; set; }
        public float DriedTrees { get; set; }
        public float Vegetation { get; set; }
        public float RottenVegetation { get; set; }
        public CulinaryHerbs CulinaryHerbs { get; set; }
        public Fruits Fruits { get; set; }
        public Grains Grains { get; set; }
        public Tubercles Tubers { get; set; }
        public Vegetables Vegetables { get; set; }
        public MedicinalHerbs MedicinalHerbs { get; set; }
        public float Poisons { get; set; }

        public Plants(string name, IExcelManager excelManager)
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
