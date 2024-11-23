namespace SocietyBuilder.Models.World
{
    // length to height is 1200 Parcels; length to width is 1650 Parcels ( 72.000 x 99.000 meters )
    public class WorldPart
    {
        public (int, int) Position { get; }
        public bool IsMagmaHub { get; }
        public string? HubDirection { get; }
        public bool IsBorder { get; }
        public bool IsDivergent { get; }
        public TectonicPlate[] TectonicPlates { get; }

        public WorldPart(
            (int, int) position, TectonicPlate[] platesNumber,
            bool isMagmaHub = false, bool isDivergent = false, string? hubDirection = null
        )
        {
            Position = position;
            TectonicPlates = platesNumber;
            IsMagmaHub = isMagmaHub;
            HubDirection = isMagmaHub ? hubDirection : null;
            IsBorder = platesNumber.Count() > 1 ? true : false;
            IsDivergent = !IsBorder ? false : isDivergent;
        }
    }
}
