using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Area : IPhysicalSpace
    {
        public Zone CenterNorth { get; set; }
        public Zone CenterSouth { get; set; }
        public Zone NorthWest { get; set; }
        public Zone SouthWest { get; set; }
        public Zone NorthEast { get; set; }
        public Zone SouthEast { get; set; }
    }
}
