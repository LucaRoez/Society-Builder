namespace SocietyBuilder.Models.World
{
    // length to height is 1200 Parcels; length to width is 1650 Parcels ( 72.000 x 99.000 meters )
    public class WorldPart
    {
        public (int, int) Position { get; }
        public bool IsMagmaHub { get; }
        public (string, float) HubVector { get; }
        public bool IsBorder { get; }
        public bool IsDivergent { get; }
        public TectonicPlate[] TectonicPlates { get; }

        public WorldPart(
            (int, int) position, TectonicPlate[] platesNumber, (string, float) hubVector,
            bool isMagmaHub = false, bool isDivergent = false
        )
        {
            Position = position;
            TectonicPlates = platesNumber;
            IsMagmaHub = isMagmaHub;
            HubVector = hubVector;
            IsBorder = platesNumber.Count() > 1 ? true : false;
            IsDivergent = !IsBorder ? false : isDivergent;
        }
    }
}
