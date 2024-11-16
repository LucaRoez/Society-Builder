namespace SocietyBuilder.Models.World
{
    // length to height is 1200 Parcels; length to width is 1650 Parcels ( 72.000 x 99.000 meters )
    public class WorldPart
    {
        public (int, int) Position { get; }
        public bool IsMagmaHub { get; }
        public TectonicPlate[] TectonicPlates { get; }

        public WorldPart((int, int) position, TectonicPlate[] platesNumber, bool? isMagmaHub = null)
        {
            Position = position;
            IsMagmaHub = isMagmaHub != null ? (bool)isMagmaHub : false;
        }
    }
}
