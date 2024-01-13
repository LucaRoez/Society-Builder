namespace SocietyBuilder.Models.Spaces.Interfaces
{
    public interface IBiome : ITerrainFeature
    {
        IAltitude[] Altitudes { get; }
        ILatitude Latitude { get; }
        ITemperature[] Temperatures { get; }
        IHumidity[] Humidities { get; }
    }
}
