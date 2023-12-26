using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Zone : IPhysicalSpace
    {
        public int ID { get; set; }
        public int OID { get; set; }
        public int AreaId { get; set; }
        public int AreaOId { get; set; }
        public Area Area { get; set; }
        public int[] ParcelIds { get; set; }
        public Parcel North { get; set; }
        public Parcel South { get; set; }
        public Parcel West { get; set; }
        public Parcel East { get; set; }

        public Zone()
        {
            OID = 1;
        }
        public Zone(int id)
        {
            OID = id;
        }
    }
}
