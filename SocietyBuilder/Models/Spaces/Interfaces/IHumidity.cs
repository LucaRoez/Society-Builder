namespace SocietyBuilder.Models.Spaces.Interfaces
{
    public interface IHumidity : ITerrainFeature
    {
        // both properties work for different PhysicalSpace level:
        float? ActualGrade { get; }             // ActualLevel is for Parcel use
        (float, float)? GradeRange { get; }     // LevelRange is for Area to Region use
    }
}
