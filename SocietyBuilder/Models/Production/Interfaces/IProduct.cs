using SocietyBuilder.Models.Population.Features;
using SocietyBuilder.Models.Population.Interfaces.IDemography;

namespace SocietyBuilder.Models.Production.Interfaces
{
    public interface IProduct
    {
        public int Id { get; }
        Necessity[] NecessitiesSatisfied { get; set; }
        float SatisfactionGiven { get; set; }
        void SetNecessitiesSatisfied();
        Product ReturnProduct(int quantity);
        List<Product> ReturnWaste();
    }
}
