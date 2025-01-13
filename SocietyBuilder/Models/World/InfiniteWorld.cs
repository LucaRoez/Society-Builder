using SocietyBuilder.Models.World.Interface;
using System.Diagnostics;
using System.Numerics;
using System;

namespace SocietyBuilder.Models.World
{
    public class InfiniteWorld : IWorld
    {
        public int Id { get; }
        public int Size { get; }
        public (int, int)[] NuclearMagmaHubs { get; }
        public WorldPart[,] World { get; }
        public (int, int)[] MainContinents { get; }
        private static string[] _Directions = new string[8]
        {
            "N", "S", "E", "W", "NE", "SE", "SW", "NW"
        };
        private int Width { get; set; }
        private int Height { get; set; }

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
            Random random = new Random();
            // create the main matrix with default logarithmic values
            (int x, int y) worldCoordinates =
            (
                Math.Max((int)Math.Log(Size * 1.4) * 40, 22),   // width
                Math.Max((int)Math.Log(Size) * 40, 16)          // height
            );
            Width = worldCoordinates.x; Height = worldCoordinates.y;
            WorldPart[,] worldParts = new WorldPart[Width, Height];

            (int, int)[] nuclearMagmaHubs = CalculateMagmaHubsGrid(worldCoordinates);
            (float magnitude, (float x, float y)? disaggregated)[,] magmaField =
                CreateMagmaVectorField(worldCoordinates, nuclearMagmaHubs);


            // setting the tectonic plates
            // these are the possible plate amount within a single WorldPart
            TectonicPlate[] lonelyPlate = new TectonicPlate[1];
            TectonicPlate[] biBorderPlate = new TectonicPlate[2];
            TectonicPlate[] triBorderPlate = new TectonicPlate[3];

            // set the plate amount according to the world size
            int plateAmount = (int)Math.Min(Math.Max(Math.Sqrt(Math.Log2(size) * 1.5), 2), 8);
            TectonicPlate[] tectonicPlates = new TectonicPlate[plateAmount];

            // set a gradient field to measure the change rate
            float[,] gradientField = new float[Width, Height];
            for (int y = 1; y < Height - 1; y++)
            {
                for (int x = 1; x < Width - 1; x++)
                {
                    float dx = (magmaField[x + 1, y].magnitude - magmaField[x - 1, y].magnitude) / 2f;
                    float dy = (magmaField[x, y + 1].magnitude - magmaField[x, y - 1].magnitude) / 2f;
                    gradientField[x, y] = (float)Math.Sqrt(dx * dx + dy * dy);
                }
            }
            // set the tectonic plates world new matrix
            for (int x = 0; x < Width; x++)
            {
                for (int y = 0; y < Height; y++)
                {
                    
                }
            }


            // take the magma hubs coordinates to set them to its equivalent WorldPart element
            foreach ((int, int) hubCoordinates in nuclearMagmaHubs)
            {
                worldParts[hubCoordinates.Item1, hubCoordinates.Item2] = new WorldPart(
                    hubCoordinates, tectonicPlates, 
                );
            }
        }

        /*   HERE'S THE MAGMA VECTOR-FIELD FLOW LOGIC   */
        private (float magnitude, (float x, float y)? disaggregated)[,] CreateMagmaVectorField((int x, int y) worldCoordinates, (int, int)[] nuclearMagmaHubs)
        {
            Random random = new Random();
            // make a matrix that simulates a vector-field
            (float magnitude, (float x, float y)? disaggregated)[,] magmaField =
                new (float, (float, float)?)[Width, Height];
            float mu = 0.9f; // resistance variable
            float distanceInfluence = 1.2f;
            float scale = 100f;

            // magma intensities calculation
            float intensityLimit = 10f;
            int lastSign = 0, consecutiveCount = 0;
            ((int x, int y) position, float intensity)[] magmaHubs = nuclearMagmaHubs.Select((m, i) =>
            {
                float randomIntensity = (float)(random.NextDouble() * intensityLimit);
                int currentSing;

                // sign value rules
                if (lastSign == 0 || consecutiveCount < 2) currentSing = random.Next(0, 2) == 0 ? -1 : 1;
                else currentSing = -lastSign;
                if (currentSing == lastSign) consecutiveCount++;
                else
                {
                    consecutiveCount = 0; lastSign = currentSing;
                }
                // sign value assignation
                float magmaIntensity = randomIntensity * currentSing;
                return (m, magmaIntensity);
            }).ToArray();

            // vector-field matrix building
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    float totalXContribution = 0;
                    float totalYContribution = 0;

                    foreach (((int x, int y) position, float intensity) hub in magmaHubs)
                    {
                        int straightX = x - hub.position.x, dy = y - hub.position.y;
                        int dx = Math.Min(Math.Abs(straightX), Width - Math.Abs(straightX));    // toroidal connection
                        int mirroredX = Width - 1 - x; // "Mercator" connection base
                        int baseBottomDist = Height - 1 - y, bottomDistance = baseBottomDist + (Height - 1 - hub.position.y);
                        int topDistance = y + hub.position.y;

                        if (dx >= bottomDistance)
                            dx = bottomDistance;
                        else if (dx >= topDistance)
                            dx = topDistance;
                        float distance = (float)Math.Sqrt(dx * dx + dy * dy) + distanceInfluence;

                        if (distance > 0)
                        {
                            // polarity interaction factor calculations
                            float polarityFactor = hub.intensity < 0 ? -1 : 1;
                            float localIntensity = Math.Abs(hub.intensity); // final magnitude of intensity

                            foreach (var otherHub in magmaHubs)
                            {
                                if (hub.position == otherHub.position) continue;

                                float otherPolarityFactor = otherHub.intensity < 0 ? -1 : 1;
                                float polarityInteraction = polarityFactor * otherPolarityFactor;

                                // polarity interaction influence
                                localIntensity += polarityInteraction * otherHub.intensity / Math.Max(1f, distance);
                            }

                            // direction and contribution calculation
                            (float x, float y) direction =
                            (
                                // official spiral formula
                                dx / distance,
                                dy / distance
                            // alternative squared formula
                            //((x - hub.position.x + Width) % Width - dx) / distance,
                            //((y - hub.position.y + Height) % Height - dy) / distance
                            );
                            float contribution = (localIntensity * scale) / (distance * mu);
                            totalXContribution += contribution * direction.x;
                            totalYContribution += contribution * direction.y;
                        }
                    }

                    // final magma vector field building
                    float magnitude = (float)Math.Sqrt(
                        totalXContribution * totalXContribution + totalYContribution * totalYContribution
                    );

                    Vector3 vectorLocation = new Vector3(x, y, 1);
                    if (magmaHubs.Any(p => p.position.x == x && p.position.y == y))
                    {
                        ((int x, int y) position, float intensity) hub =
                            magmaHubs.FirstOrDefault(p => p.position.x == x && p.position.y == y);
                        magmaField[x, y] = (hub.intensity, null);
                    }
                    else
                    {
                        float maxMagnitude = 285f;
                        float normalizedMagnitude = Math.Clamp(magnitude / maxMagnitude, 0.1f, 1f);
                        float normalizedXMagnitude = Math.Clamp(totalXContribution / maxMagnitude, 0.1f, 1f);
                        float normalizedYMagnitude = Math.Clamp(totalYContribution / maxMagnitude, 0.1f, 1f);
                        magmaField[x, y] = (normalizedMagnitude, (normalizedXMagnitude, normalizedYMagnitude));
                    }
                }
            }
            return magmaField;
        }

        /*   HERE'S JUST THE MAGMA GRID DISTRIBUTION LOGIC   */
        private (int, int)[] CalculateMagmaHubsGrid((int x, int y) worldCoordinates)
        {
            // calculate the magma hubs amount according to default proportional value
            int hubAmount = Height / 3;
            // then calculate how many rows it will step to keep magma hub proportions
            int rowAmount = (int)Math.Abs(Math.Sqrt(hubAmount * (Height / Width)));
            // and adjust it whether hubAmount doesn't reach to fill the last row, to fill the leftover hub slots
            while (hubAmount % rowAmount != 0) hubAmount++;

            // and calculate all again creating the magma hub array
            (int, int)[] nuclearMagmaHubs = new (int, int)[hubAmount];
            rowAmount = (int)Math.Abs(Math.Sqrt(hubAmount * (Height / Width)));
            int colAmount = (int)Math.Abs(Math.Sqrt(hubAmount * (Width / Height)));

            // calculate the step per axis to correctly scaling
            int xStep = Width / colAmount;
            int yStep = Height / rowAmount;
            for (int i = 0; i < hubAmount; i++)
            {
                // prepare the iteration adjustment according to its axis
                int col = i % colAmount; // set the number of rows filled with iteration cols
                int row = i / colAmount; // set the number of rows already filled
                                         // remember axis are semantically invert
                int y = xStep / 2 + col * xStep; // take the col number and multiply it to its scale (both sum the half...)
                int x = yStep / 2 + row * yStep; // take the current row to multiply it to its scale (...to reach the center)
                                                 // fill the arrays
                nuclearMagmaHubs[i] = (x, y);
            }

            return nuclearMagmaHubs;
        }
    }
}
