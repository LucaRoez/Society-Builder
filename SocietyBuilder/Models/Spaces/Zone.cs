using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Zone : IPhysicalSpace
    {
        public Guid ID { get; set; }
        public int OID { get; set; }
        public Guid RegionId { get; set; }
        public int RegionOId { get; set; }
        public Region Region { get; set; }
        public Guid[] ParcelIds { get; set; }
        public Area North { get; set; }
        public Area South { get; set; }
        public Area West { get; set; }
        public Area East { get; set; }
                //  Land Type   //  Percentage
        public Dictionary<string, int> Occupancy { get; set; }

        public int RegionPopulationId { get; set; }
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
