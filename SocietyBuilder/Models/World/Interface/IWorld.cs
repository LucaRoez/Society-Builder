namespace SocietyBuilder.Models.World.Interface
{
    public interface IWorld
    {
        int Size { get; }
        int NuclearMagmaHubs { get; }
        WorldPart[,] World { get; }
        int MainContinents { get; }
    }
}
