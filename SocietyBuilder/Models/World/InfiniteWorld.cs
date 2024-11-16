﻿using SocietyBuilder.Models.World.Interface;

namespace SocietyBuilder.Models.World
{
    public class InfiniteWorld : IWorld
    {
        public int Size { get; }
        public int NuclearMagmaHubs { get; }
        public WorldPart[,] World { get; }
        public int MainContinents { get; }

        public InfiniteWorld(string size, int? continents)
        {
            size = size.ToLower();
            switch (size)
            {
                case "small":
                    Size = 1;
                    NuclearMagmaHubs = 6;
                    MainContinents = 1;
                    break;
                case "medium":
                    Size = 2;
                    NuclearMagmaHubs = 12;
                    MainContinents = continents != null ? (int)continents : 1;
                    break;
                default:
                    Size = 2;
                    NuclearMagmaHubs = 12;
                    MainContinents = continents != null ? (int)continents : 1;
                    break;
            }
            World = CreateWorld(size);
        }

        private WorldPart[,] CreateWorld(string size)
        {
            WorldPart[,] worldParts;
            TectonicPlate[] lonelyPlate = new TectonicPlate[1];
            TectonicPlate[] biBorderPlate = new TectonicPlate[2];
            TectonicPlate[] triBorderPlate = new TectonicPlate[3];
            int slot = 1;
            // length to height: 6000 Parcels; length to width: 11.550 Parcels ( 340.000 x 693.000 meters )
            if (size == "small")
            {
                // [0][0][0][0][0][0][0]
                // [0][X][0][X][0][X][0]
                // [0][0][0][0][0][0][0]
                // [0][X][0][X][0][X][0]
                // [0][0][0][0][0][0][0]
                TectonicPlate northPlate = new(1, false);
                TectonicPlate mainPlate = new(2, true);
                TectonicPlate littlePlate = new(3, false);
                TectonicPlate oceanPlate = new(4, false);
                TectonicPlate southPlate = new(5, true);
                bool isLonely;
                bool isBiBorder;

                worldParts = new WorldPart[5, 7];
                for (int r = 0; r < 5; r++)
                {
                    if (r == 0 && r == 5) isLonely = true;
                    else isLonely = false;
                    for (int c = 0; c < 7; c++)
                    {
                        if (r == 3 && (c == 0 || c == 3 || c == 4 || c == 6)) isLonely = true;

                        if (r == 0) lonelyPlate[0] = northPlate;
                        else if (r == 1 && c >= 1 && c <= 5)
                        {
                            biBorderPlate[0] = northPlate;
                            biBorderPlate[1] = mainPlate;
                        }
                        else if (r == 1 && c == 1)
                        {
                            triBorderPlate[0] = northPlate;
                            triBorderPlate[1] = mainPlate;
                            triBorderPlate[2] = littlePlate;
                        }

                        worldParts[r, c] = new WorldPart((r, c), isLonely ? lonelyPlate : isBiBorder ? biBorderPlate : triBorderPlate, slot % 2 == 0 ? r % 2 != 0 ? true : false : false);
                        slot++;
                    }
                }
                return worldParts;
            }
            // length to height: 8400 Parcels; length to width: 14.850 Parcels ( 504.000 x 891.000 meters )
            else if (size == "medium")
            {
                // [0][0][0][0][0][0][0][0][0]
                // [0][X][0][X][0][X][0][X][0]
                // [0][0][0][0][0][0][0][0][0]
                // [0][X][0][X][0][X][0][X][0]
                // [0][0][0][0][0][0][0][0][0]
                // [0][X][0][X][0][X][0][X][0]
                // [0][0][0][0][0][0][0][0][0]
                worldParts = new WorldPart[7, 9];
                for (int r = 0; r < 7; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        worldParts[r, c] = new WorldPart((r, c), slot % 2 == 0 ? r % 2 != 0 ? true : false : false);
                        slot++;
                    }
                }
                return worldParts;
            }
            else
            {
                // default world is the Medium
                worldParts = new WorldPart[7, 9];
                for (int r = 0; r < 7; r++)
                {
                    for (int c = 0; c < 9; c++)
                    {
                        worldParts[r, c] = new WorldPart((r, c), slot % 2 == 0 ? r % 2 != 0 ? true : false : false);
                        slot++;
                    }
                }
                return worldParts;
            }
        }
    }
}
