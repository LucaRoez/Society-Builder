using SocietyBuilder.Models.Population.Interfaces.IDemography;

namespace SocietyBuilder.Models.Production.Interfaces
{
    public interface IProduct
    {
        public int Id { get; }
        Product ReturnProduct(int quantity);
        List<Product> ReturnWaste();
    }
}
