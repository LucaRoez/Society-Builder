using SocietyBuilder.Models.Production.Interfaces;

namespace SocietyBuilder.Models.Spaces.Occupancy.Elements
{
    public class Resource
    {
        public string Name { get; set; }
        public IProduct[] Products { get; set; }
        public string Humidity { get; set; }
        public string Temperature { get; set; }
        public double Height { get; set; }
    }
}
