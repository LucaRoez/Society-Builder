using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Region : IPhysicalSpace
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid[] ZoneIDs { get; set; } = new Guid[6];
        public Zone NorthCenter { get; set; }
        public Zone SouthCenter { get; set; }
        public Zone NorthWest { get; set; }
        public Zone SouthWest { get; set; }
        public Zone NorthEast { get; set; }
        public Zone SouthEast { get; set; }

        public Region[] Neighbors { get; set; } = new Region[6];

        public Polis Population { get; set; } = new Polis();

        public Region()
        {
        }
    }
}
