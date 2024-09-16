using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.IConstruction;

namespace SocietyBuilder.Models.Spaces
{
    public class Parcel : IPhysicalSpace
    {
        public Guid ID { get; set; }
        public int OID { get; set; }
        public Guid AreaID { get; set; }
        public int AreaOID { get; set; }
        public Area Area { get; set; }
        public string BuildingKind { get; set; }
        public double BuildingTerritory { get; set; }

        public IBuildable[,] Lands = new IBuildable[3,3];

        public int AreaPopulationId { get; set; }
        public int PopulationId { get; set; }
        public Citizen[] Population { get; set; }
        public int Inhabitants { get; set; }
        public Dictionary<string, double> Resources { get; set; }

        public Parcel()
        {
            OID = 1;
        }
        public Parcel(int id)
        {
            OID = id;
        }
    }
}
