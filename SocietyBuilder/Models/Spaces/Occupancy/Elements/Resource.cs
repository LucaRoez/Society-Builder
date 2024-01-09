using SocietyBuilder.Models.Production.Interfaces;

namespace SocietyBuilder.Models.Spaces.Occupancy.Elements
{
    public class Resource
    {
        public string Name { get; set; }
        public IRawProduct[] Products { get; set; }
    }
}
