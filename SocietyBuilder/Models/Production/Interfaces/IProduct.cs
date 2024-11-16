using SocietyBuilder.Models.Activity.Interfaces;
using SocietyBuilder.Models.Population.Features;

namespace SocietyBuilder.Models.Production.Interfaces
{
    public interface IProduct
    {
        public int Id { get; }
        float Utility { get; set; }
        Product ReturnProduct(int quantity);
        List<Product> ReturnWaste();
    }
}
