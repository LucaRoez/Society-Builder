using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Area : IPhysicalSpace
    {
        public int ID { get; set; }
        public int OID { get; set; }
        public int[] ZoneIDs { get; set; }
        public Zone NorthCenter { get; set; }
        public Zone SouthCenter { get; set; }
        public Zone NorthWest { get; set; }
        public Zone SouthWest { get; set; }
        public Zone NorthEast { get; set; }
        public Zone SouthEast { get; set; }

        public Area()
        {
            OID = 1;
        }
        public Area(int id)
        {
            OID = id;
        }
    }
}
