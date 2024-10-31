namespace SocietyBuilder.Models.Population.Interfaces.IDemography
{
    public interface INiche : IDemographyFactor
    {
        int Id { get; }
        float Level { get; set; }
        float CapacityOfUse { get; set; }
    }
}
