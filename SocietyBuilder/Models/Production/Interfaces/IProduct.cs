using SocietyBuilder.Models.Population.Interfaces.IDemography;

namespace SocietyBuilder.Models.Production.Interfaces
{
    public interface IProduct
    {
        Product ReturnProduct(int quantity);
        List<Product> ReturnWaste();
    }
}
