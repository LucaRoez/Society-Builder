using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    public class Zone : IPhysicalSpace
    {
        public Parcel North { get; set; }
        public Parcel South { get; set; }
        public Parcel West { get; set; }
        public Parcel East { get; set; }
    }
}
