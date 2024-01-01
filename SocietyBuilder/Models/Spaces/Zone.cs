using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Zone : IPhysicalSpace
    {
        public Guid ID { get; set; }
        public int OID { get; set; }
        public Guid AreaId { get; set; }
        public int AreaOId { get; set; }
        public Area Area { get; set; }
        public Guid[] ParcelIds { get; set; }
        public Parcel North { get; set; }
        public Parcel South { get; set; }
        public Parcel West { get; set; }
        public Parcel East { get; set; }
                //  Land Type   //  Percentage
        public Dictionary<string, int> Occupancy { get; set; }

        public int AreaPopulationId { get; set; }
        public int PopulationId { get; set; }
        public Polis Population { get; set; }
        public int[] PopulationIds { get; set; }

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
