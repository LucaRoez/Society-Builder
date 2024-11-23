using SocietyBuilder.Models.World.Interface;

namespace SocietyBuilder.Models.World
{
    public class InfiniteWorld : IWorld
    {
        public int Size { get; }
        public (int, int)[] NuclearMagmaHubs { get; }
        public WorldPart[,] World { get; }
        public (int, int)[] MainContinents { get; }
        private static string[] _Directions = new string[8]
        {
            "N", "S", "E", "W", "NE", "SE", "SW", "NW"
        };

        public InfiniteWorld()
        {
        }

        public InfiniteWorld(int size, int? continents)
        {
            InfiniteWorld world = CreateWorld(size <= 0 ? 1 : size, continents);
            Size = size;
            NuclearMagmaHubs = world.NuclearMagmaHubs;
            World = world.World;
            MainContinents = world.MainContinents;
        }

        private InfiniteWorld CreateWorld(int size, int? continents)
        {
            // create the main matrix with default logarithmic values
            var random = new Random();
            (int x, int y) worldCoordinates = 
                (
                    Math.Max((int)Math.Log2(size) * 40, 16),        // width
                    Math.Max((int)Math.Log2(size * 1.4) * 40, 22)   // height
                );
            WorldPart[,] worldParts = new WorldPart[worldCoordinates.x, worldCoordinates.y];

            // calculate the magma hubs amount according to default proportional value
            int hubAmount = worldCoordinates.y / 3;
            // then calculate how many rows it will require
            int rowAmount = (int)Math.Abs(Math.Sqrt(hubAmount * (worldCoordinates.y / worldCoordinates.x)));
            // and adjust it whether hubAmount doesn't reach to fill the last row
            while (hubAmount % rowAmount != 0) hubAmount++;

            // and calculate all again creating the magma hub array
            (int, int)[] nuclearMagmaHubs = new (int, int)[hubAmount];
            rowAmount = (int)Math.Abs(Math.Sqrt(hubAmount * (worldCoordinates.y / worldCoordinates.x)));
            int colAmount = (int)Math.Abs(Math.Sqrt(hubAmount * (worldCoordinates.x / worldCoordinates.y)));

            // calculate the step per axis to correctly scaling
            int xStep = worldCoordinates.x / colAmount;
            int yStep = worldCoordinates.y / rowAmount;
            for (int i = 0; i  < nuclearMagmaHubs.Length; i++)
            {
                // prepare the iteration adjustment according to its axis
                int col = i % colAmount; // set the number of rows filled with iteration cols
                int row = i / colAmount; // set the number of rows already filled
                // remember axis are semantically invert
                int y = xStep / 2 + col * xStep; // take the col number and multiply it to its scale
                int x = yStep / 2 + row * yStep; // take the current row to multiply it to its scale
                // fill the arrays
                nuclearMagmaHubs[i] = (x, y);
            }

            // setting the tectonic plates
            // these are the possible plate amount within a single WorldPart
            TectonicPlate[] lonelyPlate = new TectonicPlate[1];
            TectonicPlate[] biBorderPlate = new TectonicPlate[2];
            TectonicPlate[] triBorderPlate = new TectonicPlate[3];

            // set the plate amount according to the world size
            int plateAmount = (int)Math.Min(Math.Max(Math.Sqrt(Math.Log2(size) * 1.5), 2), 8);
            TectonicPlate[] tectonicPlates = new TectonicPlate[plateAmount];
            for ()
        }
    }
}
