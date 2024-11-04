using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Zone : IPhysicalSpace
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public int OID { get; set; }
        public Guid RegionId { get; set; }
        public Region Region { get; set; }
        public Guid[] AreaIds { get; set; } = new Guid[3];
        public Area? North { get; set; }
        public Area? South { get; set; }
        public Area West { get; set; }
        public Area East { get; set; }

        public Zone?[] Neighbors { get; set; } = new Zone?[8];

        public Polis Population { get; set; } = new Polis();

        public Zone(int id, Region region)
        {
            OID = id;
            Region = region;
            RegionId = region.ID;
        }

        public Zone?[] SetNeighbors()
        {
            Region parent = Region;
            if (OID == 1)           // West North Zone
            {
                Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null;
                Neighbors[3] = null; Neighbors[4] = Region.NorthCenter;
                Neighbors[5] = null; Neighbors[6] = Region.SouthWest; Neighbors[7] = Region.SouthCenter;
            }
            else if (OID == 2)      // Center North Zone
            {
                Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null; 
                Neighbors[3] = Region.NorthWest; Neighbors[4] = Region.NorthEast;
                Neighbors[5] = Region.SouthWest; Neighbors[6] = Region.SouthCenter; Neighbors[7] = Region.SouthEast;
            }
            else if (OID == 3)      // East North Zone
            {
                Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null;
                Neighbors[3] = Region.NorthCenter; Neighbors[4] = null;
                Neighbors[5] = Region.SouthCenter; Neighbors[6] = Region.SouthEast; Neighbors[7] = null;
            }
            else if (OID == 4)      // West South Zone
            {
                Neighbors[0] = null; Neighbors[1] = Region.NorthWest; Neighbors[2] = Region.NorthCenter;
                Neighbors[3] = null; Neighbors[4] = Region.SouthCenter;
                Neighbors[5] = null; Neighbors[6] = null; Neighbors[7] = null;
            }
            else if (OID == 5)      // Center South Zone
            {
                Neighbors[0] = Region.NorthWest; Neighbors[1] = Region.NorthCenter; Neighbors[2] = Region.NorthEast;
                Neighbors[3] = Region.SouthWest; Neighbors[4] = Region.SouthEast;
                Neighbors[5] = null; Neighbors[6] = null; Neighbors[7] = null;
            }
            else if (OID == 6)      // East South Zone
            {
                Neighbors[0] = Region.NorthCenter; Neighbors[1] = Region.NorthEast; Neighbors[2] = null;
                Neighbors[3] = Region.SouthCenter; Neighbors[4] = null;
                Neighbors[5] = null; Neighbors[6] = null; Neighbors[7] = null;
            }

            return Neighbors;
        }
    }
}
