namespace SocietyBuilder.Models.World.Interface
{
    public interface ITectonicPlate
    {
        int Id { get; }
        bool IsContinental { get; }
        bool IsShield { get; }
        bool IsMassif { get; }
        List<bool> Direction { get; }
    }
}
