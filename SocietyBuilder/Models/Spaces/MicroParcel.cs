using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class MicroParcel : IPhysicalSpace
    {
        public int ID { get; set; }
        public int OID { get; set; }
        public int ParcelID { get; set; }
        public int ParcelOID { get; set; }
        public Parcel Parcel { get; set; }
        public string BuildingKind { get; set; }
        public int Inhabitants { get; set; }
        public string[] States { get; set; }
        public int ProductionPower { get; set; }
        public Dictionary<string, int> Endurances { get; set; }
        public Dictionary<int, Dictionary<IActivity, int>> Incomes { get; set; }

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
