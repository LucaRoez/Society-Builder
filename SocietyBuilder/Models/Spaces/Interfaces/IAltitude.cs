namespace SocietyBuilder.Models.Spaces.Interfaces
{
    public interface IAltitude : ITerrainFeature
    {
        // both properties work for different PhysicalSpace level:
        float? ActualLevel { get; }             // ActualLevel is for Parcel use
        (float, float)? LevelRange { get; }     // LevelRange is for Area to Region use
    }
}
