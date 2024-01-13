namespace SocietyBuilder.Models.Spaces.Interfaces
{
    public interface IHumidity : ITerrainFeature
    {
        double Grades { get; }
    }
}
