using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Area : IPhysicalSpace
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public int OID { get; set; }
        public Guid ZoneID { get; set; }
        public int ZoneOID { get; set; }
        public Zone Zone { get; set; }
        public Guid[] ParcelIDs { get; set; }

        public Parcel?[,] Parcels { get; set; } = new Parcel?[16, 16];

        public Area?[] Neighbors { get; set; } = new Area[7];

        public Polis Population { get; set; }

        public Area(int id, Zone zone)
        {
            OID = id;
            Zone = zone;
            ZoneID = zone.ID;
            ZoneOID = zone.OID;
        }

        public Area?[] SetNeighbors()
        {
            if (ZoneOID == 1)           // North West
            {
                if (OID == 1)   // North
                {
                    Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null;
                    Neighbors[3] = null; Neighbors[4] = Zone.Region.NorthCenter.West;
                    Neighbors[5] = Zone.West; Neighbors[6] = Zone.East;
                }
                else if (OID == 3)   // West
                {
                    Neighbors[0] = null; Neighbors[1] = Zone.North;
                    Neighbors[2] = null; Neighbors[3] = Zone.East;
                    Neighbors[4] = null; Neighbors[5] = Zone.Region.SouthWest.West; Neighbors[6] = Zone.Region.SouthWest.East;
                }
                else if (OID == 4)   // East
                {
                    Neighbors[0] = Zone.North; Neighbors[1] = Zone.Region.NorthCenter.West;
                    Neighbors[2] = Zone.West; Neighbors [3] = Zone.Region.NorthCenter.South;
                    Neighbors[4] = Zone.Region.SouthWest.West; Neighbors[5] = Zone.Region.SouthWest.East; Neighbors[6] = Zone.Region.SouthCenter.North;
                }
            }
            else if (ZoneOID == 2)      // North Center
            {
                if (OID == 2)   // South
                {
                    Neighbors[0] = Zone.West; Neighbors[1] = Zone.East;
                    Neighbors[2] = Zone.Region.NorthWest.East; Neighbors[3] = Zone.Region.NorthEast.West;
                    Neighbors[4] = Zone.Region.SouthWest.West; Neighbors[5] = Zone.Region.SouthWest.East; Neighbors[6] = Zone.Region.SouthCenter.North;
                }
                if (OID == 3)   // West
                {
                    Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null;
                    Neighbors[3] = Zone.Region.NorthWest.North; Neighbors [4] = Zone.East;
                    Neighbors[5] = Zone.Region.NorthWest.East; Neighbors[6] = Zone.South;
                }
                if (OID == 4)   // East
                {
                    Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null;
                    Neighbors[3] = Zone.West; Neighbors[4] = Zone.Region.NorthEast.North;
                    Neighbors[5] = Zone.North; Neighbors[6] = Zone.Region.NorthEast.West;
                }
            }
            else if (ZoneOID == 3)      // North East
            {
                if (OID == 1)   // North
                {
                    Neighbors[0] = null; Neighbors[1] = null; Neighbors[2] = null;
                    Neighbors [3] = Zone.Region.NorthCenter.East; Neighbors[4] = null;
                    Neighbors[5] = Zone.West; Neighbors[6] = Zone.East;
                }
                if (OID == 3)   // West
                {
                    Neighbors[0] = Zone.Region.NorthCenter.East; Neighbors[1] = Zone.North;
                    Neighbors[2] = Zone.Region.NorthCenter.South; Neighbors[3] = Zone.East;
                    Neighbors[4] = Zone.Region.SouthCenter.North; Neighbors [5] = Zone.Region.SouthEast.West; Neighbors[6] = Zone.Region.SouthEast.East;
                }
                if (OID == 4)   // East
                {
                    Neighbors[0] = Zone.North; Neighbors[1] = null;
                    Neighbors[2] = Zone.West; Neighbors[3] = null;
                    Neighbors[4] = Zone.Region.SouthEast.West; Neighbors[5] = Zone.Region.SouthEast.East; Neighbors[6] = null;
                }
            }
            else if (ZoneOID == 4)      // South West
            {
                if (OID == 2)   // South
                {
                    Neighbors[0] = Zone.West; Neighbors[1] = Zone.East;
                    Neighbors[2] = null; Neighbors[3] = Zone.Region.SouthCenter.West;
                    Neighbors[4] = null; Neighbors[5] = null; Neighbors[6] = null;
                }
                if (OID == 3)   // West
                {
                    Neighbors[0] = null; Neighbors[1] = Zone.Region.NorthWest.West; Neighbors[2] = Zone.Region.NorthWest.East;
                    Neighbors[3] = null; Neighbors[4] = Zone.East;
                    Neighbors[5] = null; Neighbors[6] = Zone.South;
                }
                if (OID == 4)   // East
                {
                    Neighbors[0] = Zone.Region.NorthWest.West; Neighbors[1] = Zone.Region.NorthWest.East; Neighbors[2] = Zone.Region.NorthCenter.South;
                    Neighbors[3] = Zone.West; Neighbors[4] = Zone.Region.SouthCenter.North;
                    Neighbors[5] = Zone.South; Neighbors[6] = Zone.Region.SouthCenter.West;
                }
            }
            else if (ZoneOID == 5)      // South Center
            {
                if (OID == 1)   // North
                {
                    Neighbors[0] = Zone.Region.NorthWest.East; Neighbors[1] = Zone.Region.NorthCenter.South; Neighbors[2] = Zone.Region.NorthEast.West;
                    Neighbors[3] = Zone.Region.SouthWest.East; Neighbors[4] = Zone.Region.SouthEast.West;
                    Neighbors[5] = Zone.West; Neighbors[6] = Zone.East;
                }
                if (OID == 3)   // West
                {
                    Neighbors[0] = Zone.Region.SouthWest.East; Neighbors[1] = Zone.North;
                    Neighbors[2] = Zone.Region.SouthWest.South; Neighbors[3] = Zone.East;
                    Neighbors[4] = null; Neighbors[5] = null; Neighbors[6] = null;
                }
                if (OID == 4)   // East
                {
                    Neighbors[0] = Zone.North; Neighbors[1] = Zone.Region.SouthEast.West;
                    Neighbors[2] = Zone.West; Neighbors[3] = Zone.Region.SouthEast.South;
                    Neighbors[4] = null; Neighbors[5] = null; Neighbors[6] = null;
                }
            }
            else if (ZoneOID == 6)      // South East
            {
                if (OID == 2)   // South
                {
                    Neighbors[0] = Zone.West; Neighbors[1] = Zone.East;
                    Neighbors[2] = Zone.Region.SouthCenter.East; Neighbors[3] = null;
                    Neighbors[4] = null; Neighbors[5] = null; Neighbors[6] = null;
                }
                if (OID == 3)   // West
                {
                    Neighbors[0] = Zone.Region.NorthCenter.South; Neighbors[1] = Zone.Region.NorthEast.West; Neighbors[2] = Zone.Region.NorthEast.East;
                    Neighbors[3] = Zone.Region.SouthCenter.North; Neighbors[4] = Zone.East;
                    Neighbors[5] = Zone.Region.SouthCenter.East; Neighbors[6] = Zone.South;
                }
                if (OID == 4)   // East
                {
                    Neighbors[0] = Zone.Region.NorthEast.West; Neighbors[1] = Zone.Region.NorthEast.East; Neighbors[2] = null;
                    Neighbors[3] = Zone.West; Neighbors[4] = null;
                    Neighbors[5] = Zone.South; Neighbors[6] = null;
                }
            }

            return Neighbors;
        }

        /*
         
        -------------  Parcels Matrix  -------------
        
                  Straight Pointed Triangule
        
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][0][0][0][0][*][*][*][*][*][*]
        [*][*][*][*][*][0][0][0][0][0][0][*][*][*][*][*]
        [*][*][*][*][0][0][0][0][0][0][0][0][*][*][*][*]
        [*][*][*][*][0][0][0][0][0][0][0][0][*][*][*][*]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [*][*][0][0][0][0][0][0][0][0][0][0][0][0][*][*]
        [*][*][0][0][0][0][0][0][0][0][0][0][0][0][*][*]
        [*][0][0][0][0][0][0][0][0][0][0][0][0][0][0][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][0][0][0][0][0][0][0][0][0][0][0][0][0][0][*]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [*][*][*][*][*][*][0][0][0][0][*][*][*][*][*][*]
        
                  Western Straight Trapezoid
        
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][0][0][*][*][*][*][*]
        [*][*][*][*][*][*][0][0][0][0][0][0][0][0][*][*]
        [*][*][*][*][*][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][*][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        
                  Eastern Straight Trapezoid
        
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][0][0][0][0][*][*][*][*][*][*][*]
        [*][*][0][0][0][0][0][0][0][0][*][*][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][*][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][*][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        
                  Inverted Pointed Triangle
        
        [*][*][*][*][*][*][0][0][0][0][*][*][*][*][*][*]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [*][0][0][0][0][0][0][0][0][0][0][0][0][0][0][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][0][0][0][0][0][0][0][0][0][0][0][0][0][0][*]
        [*][*][0][0][0][0][0][0][0][0][0][0][0][0][*][*]
        [*][*][0][0][0][0][0][0][0][0][0][0][0][0][*][*]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [*][*][*][*][0][0][0][0][0][0][0][0][*][*][*][*]
        [*][*][*][*][0][0][0][0][0][0][0][0][*][*][*][*]
        [*][*][*][*][*][0][0][0][0][0][0][*][*][*][*][*]
        [*][*][*][*][*][*][0][0][0][0][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        
                  Western Inverted Trapezoid
        
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][0][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][*][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][*][0][0][0][0][0][0][0][0][0][0][0]
        [*][*][*][*][*][*][0][0][0][0][0][0][0][0][*][*]
        [*][*][*][*][*][*][*][0][0][0][0][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        
                  Eastern Inverted Trapezoid
        
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][0]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][0][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][0][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][0][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][0][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][*][*][*][*][*]
        [0][0][0][0][0][0][0][0][0][0][0][*][*][*][*][*]
        [*][*][0][0][0][0][0][0][0][0][*][*][*][*][*][*]
        [*][*][*][*][*][0][0][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][0][0][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]
        [*][*][*][*][*][*][*][*][*][*][*][*][*][*][*][*]


         */
    }
}
