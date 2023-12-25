using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Parcel : IPhysicalSpace
    {
        public string Location { get; set; }
        public string[] MicroParcels { get; set; }
    }
}
