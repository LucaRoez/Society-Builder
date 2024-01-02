using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Population;

namespace SocietyBuilder.Models.Spaces
{
    public class MicroParcel : IPhysicalSpace
    {
        public Guid ID { get; set; }
        public int OID { get; set; }
        public Guid ParcelID { get; set; }
        public int ParcelOID { get; set; }
        public Parcel Parcel { get; set; }
        public string BuildingKind { get; set; }
        public double BuildingTerritory { get; set; }

        public int ParcelPopulationId { get; set; }
        public int PopulationId { get; set; }
        public Citizen[] Population { get; set; }
        public int Inhabitants { get; set; }
        public Dictionary<string, double> Resources { get; set; }

        public MicroParcel()
        {
            OID = 1;
        }
        public MicroParcel(int id)
        {
            OID = id;
        }
    }
}
