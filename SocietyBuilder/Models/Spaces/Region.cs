using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Spaces.Features.Latitude;
using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces
{
    // Region length to height is 48 Parcels; length to width is 66 Parcels
    public class Region : IPhysicalSpace
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public Guid[] ZoneIDs { get; set; } = new Guid[6];
        public ILatitude Latitude { get; set; }
        public Zone NorthCenter { get; set; }
        public Zone SouthCenter { get; set; }
        public Zone NorthWest { get; set; }
        public Zone SouthWest { get; set; }
        public Zone NorthEast { get; set; }
        public Zone SouthEast { get; set; }

        public (int, int)?[,] Coordinates { get; set; }

        public Region[] Neighbors { get; set; } = new Region[6];

        public Polis Population { get; set; } = new Polis();

        public Region(string latitude)
        {
            switch (latitude.ToLower())
            {
                case "tropical": Latitude = new Tropical(); break;
                case "subtropical": Latitude = new Subtropical(); break;
                case "subpolar": Latitude = new Subpolar(); break;
                case "polar": Latitude = new Polar(); break;
                default: Latitude = new Subtropical(); break;
            }
        }

        // tool for drawing automation
        // this patter corresponds to the row break relative to its matrix 
        private static int[] HexagonalMap = new int[48]
        {
            0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0,        // the hexagon, where each row
            1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1,     // reciprocates to each quarter (Area object)
            0, 1, 1, 1, 0, 1, 0, 1, 0, 1, 1, 0,     // counting from its top to its bottom
            1, 0, 1, 1, 0, 1, 0, 1, 0, 1, 1, 1      // in a vertical slice
        };
        private static int[] DrawingLiners = new int[8] 
        {                                   // indexs:     0    -    1    -    2   -   3 - 4   -   5   -    6    -    7
            15, 15, 17, 32, 33, 49, 50, 50  // sequence: 1 outter, 1 helper, 1 inner, 2 middles, 1 inner, 1 helper, 1 outter
        };

        public void SetCoordinates()
        {
            for (int x = 0; x < 48; x++)
            {
                // from an hexagonal matrix coordinates I set the localized Parcels inside their Region
                // translating from a smaller matrix to a bigger one just for cleaner
                // neighbor localization and path finding purpuses

                int modifier = HexagonalMap[x];
                //                     outter layer "liners"
                if (x < 24)
                {
                    DrawingLiners[0] -= modifier; DrawingLiners[7] += modifier;
                }
                else
                {
                    DrawingLiners[0] += modifier; DrawingLiners[7] -= modifier;
                }

                if (x < 12)
                {
                    //   inner main "liners"    ||       helper "liners"
                    DrawingLiners[2] += modifier; DrawingLiners[1] += modifier;
                    DrawingLiners[5] -= modifier; DrawingLiners[6] -= modifier;
                }
                else if (x >= 9 && x <= 15)
                {
                    if (x < 13) // watch this adjustment: let this movement for middle "liners" adapt the figure shape,
                                // disengaging intentionally the inner and helper "liners", because there's where a 0 must be implemented
                    {   //                     middle "liners"
                        DrawingLiners[3] -= x != 10 ? modifier == 0 ? 2 : modifier : 3;
                        DrawingLiners[4] += x != 10 ? modifier == 0 ? 2 : modifier : 3;
                    }
                    else
                    {   //      inner main "liners"       ||       middle "liners"      ||          helper "liners"
                        DrawingLiners[2] -= x != 14 ? 2 : 3; DrawingLiners[3] += modifier; DrawingLiners[1] += x != 14 ? 2 : 3;
                        DrawingLiners[5] += x != 14 ? 2 : 3; DrawingLiners[4] -= modifier; DrawingLiners[6] -= x != 14 ? 2 : 3;
                    }
                }
                else if (x > 15 && x < 24)
                {   // only the middles must hold the track
                    DrawingLiners[3] += modifier;
                    DrawingLiners[4] -= modifier;
                }
                else if (x >= 24 && x < 36)
                {
                    // just invert middles
                    DrawingLiners[3] -= modifier;
                    DrawingLiners[4] += modifier;

                    if (x == 33)
                    {   //   inner main "liners"   ||       helper "liners"
                        DrawingLiners[2] += modifier; DrawingLiners[1] -= modifier;
                        DrawingLiners[5] -= modifier; DrawingLiners[6] += modifier;
                    }
                    else if (x >= 34)
                    {   //      inner main "liners"       ||          helper "liners"
                        DrawingLiners[2] += x != 34 ? 2 : 3; DrawingLiners[1] -= x != 34 ? 2 : 3;
                        DrawingLiners[5] -= x != 34 ? 2 : 3; DrawingLiners[6] += x != 34 ? 2 : 3;
                    }
                }
                else if (x >= 36 && x <= 39)
                {   //          inner main "liners"          ||                  middle "liners"                ||               helper "liners"
                    DrawingLiners[2] -= x != 36 ? modifier : 1; DrawingLiners[3] += x != 36 ? x != 38 ? 2 : 3 : 0; DrawingLiners[1] += x != 36 ? modifier : 1;
                    DrawingLiners[5] += x != 36 ? modifier : 1; DrawingLiners[4] -= x != 36 ? x != 38 ? 2 : 3 : 0; DrawingLiners[6] -= x != 36 ? modifier : 1;
                }
                else if (x > 39)
                {   //   at last only the inner "liners" must be moved
                    DrawingLiners[2] -= modifier;
                    DrawingLiners[5] += modifier;
                }

                for (int y = 0; y < 66; y++) DrawFrontiers(x, y);
            }
        }

        private void DrawFrontiers(int x, int y)
        {
            if (y >= DrawingLiners[0] && y <= DrawingLiners[7])
            {
                if (x < 9)
                {
                    if (y >= DrawingLiners[0] && y < DrawingLiners[2])
                        SetNorthWestUpperTriangle(x, y);

                    else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                        SetCenterUpperTrapezoids(x, y, DrawingLiners[2]);

                    else if (y >= DrawingLiners[4] && y < DrawingLiners[5])
                        SetCenterUpperTrapezoids(x, y, DrawingLiners[4]);

                    else if (y >= DrawingLiners[5] && y <= DrawingLiners[7])
                        SetNorthEastUpperTriangle(x, y);
                }
                else if (x >= 9 && x <= 15)
                {
                    if (x < 12)
                    {
                        if (y >= DrawingLiners[0] && y < DrawingLiners[2])
                            SetNorthWestUpperTriangle(x, y);

                        else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                            SetCenterUpperTrapezoids(x, y, DrawingLiners[2]);

                        else if (y > DrawingLiners[3] && y < DrawingLiners[4])
                            SetNorthCenterLowerTriangle(x, y);

                        else if (y >= DrawingLiners[4] && y < DrawingLiners[5])
                            SetCenterUpperTrapezoids(x, y, DrawingLiners[4]);

                        else if (y >= DrawingLiners[5] && y <= DrawingLiners[7])
                            SetNorthEastUpperTriangle(x, y);
                    }
                    else
                    {
                        if (y >= DrawingLiners[0] && y <= DrawingLiners[1])
                            SetWesternLeftLowerTrapezoid(x, y);

                        if (y > DrawingLiners[1] && y < DrawingLiners[2])
                            SetNorthWestUpperTriangle(x, y);

                        else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                            SetWesternRightLowerTrapezoid(x, y);

                        else if (y > DrawingLiners[3] && y < DrawingLiners[4])
                            SetNorthCenterLowerTriangle(x, y);

                        else if (y >= DrawingLiners[4] && y <= DrawingLiners[5])
                            SetEasternLeftLowerTrapezoid(x, y);

                        else if (y > DrawingLiners[5] && y < DrawingLiners[6])
                            SetNorthEastUpperTriangle(x, y);

                        else if (y >= DrawingLiners[6] && y <= DrawingLiners[7])
                            SetEasternRightLowerTrapezoid(x, y);
                    }
                }
                else if (x > 15 && x < 24)
                {
                    if (y >= DrawingLiners[0] && y < DrawingLiners[2])
                        SetWesternLeftLowerTrapezoid(x, y);

                    else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                        SetWesternRightLowerTrapezoid(x, y);

                    else if (y > DrawingLiners[3] && y < DrawingLiners[4])
                        SetNorthCenterLowerTriangle(x, y);

                    else if (y >= DrawingLiners[4] && y < DrawingLiners[5])
                        SetEasternLeftLowerTrapezoid(x, y);

                    else if (y >= DrawingLiners[5] && y <= DrawingLiners[7])
                        SetEasternRightLowerTrapezoid(x, y);
                }
                else if (x >= 24 && x < 33)
                {
                    if (y >= DrawingLiners[0] && y < DrawingLiners[2])
                        SetWesternLeftUpperTrapezoid(x, y);

                    else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                        SetWesternRightUpperTrapezoid(x, y);

                    else if (y > DrawingLiners[3] && y < DrawingLiners[4])
                        SetSouthCenterUpperTriangle(x, y);

                    else if (y >= DrawingLiners[4] && y < DrawingLiners[5])
                        SetEasternLeftUpperTrapezoid(x, y);

                    else if (y >= DrawingLiners[5] && y <= DrawingLiners[7])
                        SetEasternRightUpperTrapezoid(x, y);
                }
                else if (x >= 33 && x < 36)
                {
                    if (y >= DrawingLiners[0] && y <= DrawingLiners[1])
                        SetWesternLeftUpperTrapezoid(x, y);

                    if (y > DrawingLiners[1] && y < DrawingLiners[2])
                        SetNorthWestUpperTriangle(x, y);

                    else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                        SetWesternRightUpperTrapezoid(x, y);

                    else if (y > DrawingLiners[3] && y < DrawingLiners[4])
                        SetSouthCenterUpperTriangle(x, y);

                    else if (y >= DrawingLiners[4] && y <= DrawingLiners[5])
                        SetEasternLeftUpperTrapezoid(x, y);

                    else if (y > DrawingLiners[5] && y < DrawingLiners[6])
                        SetNorthEastUpperTriangle(x, y);

                    else if (y >= DrawingLiners[6] && y <= DrawingLiners[7])
                        SetEasternRightUpperTrapezoid(x, y);
                }
                else if (x >= 36 && x <= 39)
                {
                    if (y >= DrawingLiners[0] && y < DrawingLiners[2])
                        SetSouthWestLowerTriangle(x, y);

                    else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                        SetCenterLowerTrapezoids(x, y, DrawingLiners[2]);

                    else if (y > DrawingLiners[3] && y < DrawingLiners[4])
                        SetSouthCenterUpperTriangle(x, y);

                    else if (y >= DrawingLiners[4] && y < DrawingLiners[5])
                        SetCenterLowerTrapezoids(x, y, DrawingLiners[4]);

                    else if (y >= DrawingLiners[5] && y <= DrawingLiners[7])
                        SetSouthEastLowerTriangle(x, y);
                }
                else if (x > 39)
                {
                    if (y >= DrawingLiners[0] && y < DrawingLiners[2])
                        SetSouthWestLowerTriangle(x, y);

                    else if (y >= DrawingLiners[2] && y <= DrawingLiners[3])
                        SetCenterLowerTrapezoids(x, y, DrawingLiners[2]);

                    else if (y >= DrawingLiners[4] && y < DrawingLiners[5])
                        SetCenterLowerTrapezoids(x, y, DrawingLiners[4]);

                    else if (y >= DrawingLiners[5] && y <= DrawingLiners[7])
                        SetSouthEastLowerTriangle(x, y);
                }
            }

            else Coordinates[x, y] = null;
        }
        // first half:
        private void SetNorthWestUpperTriangle(int x, int y) => Coordinates[x, y] = (x + 1, y - 8); // the subtracting number of "y" is: the result of subtracting the minimum "y" by the inner space difference into the area matrix, "6" always for triangles (so the result is always 8)
        private void SetCenterUpperTrapezoids(int x, int y, int minimumY) => Coordinates[x, y] = (x, y - minimumY); // always the same than minimum "y"
        private void SetNorthEastUpperTriangle(int x, int y) => Coordinates[x, y] = (x + 1, y - 42); // same as SetNorthWestUpperTriangle but with 42 as static result (e.g.: starts with 49 - 6)
        private void SetWesternLeftLowerTrapezoid(int x, int y) => Coordinates[x, y] = (x - 8, y); // here also catch the "x" logic because of its absolute distance from the hexagonal top (e.g.: 12 - 4 = 8)
        private void SetWesternRightLowerTrapezoid(int x, int y) => Coordinates[x, y] = (x - 8, y - 16); // same as the trapezoid operation, for "y" is 23 - 7 = 16
        private void SetNorthCenterLowerTriangle(int x, int y) => Coordinates[x, y] = (x + 1, y - 25); // same as the triangles operation, in this case starts with: 31 - 6 = 25
        private void SetEasternLeftLowerTrapezoid(int x, int y) => Coordinates[x, y] = (x - 8, y - 34); // 41 - 7
        private void SetEasternRightLowerTrapezoid(int x, int y) => Coordinates[x, y] = (x - 8, y - 50); // 57 - 7
        // second half:
        private void SetWesternLeftUpperTrapezoid(int x, int y) => Coordinates[x, y] = (x - 24, y);
        private void SetWesternRightUpperTrapezoid(int x, int y) => Coordinates[x, y] = (x - 24, y - 16);
        private void SetSouthCenterUpperTriangle(int x, int y) => Coordinates[x, y] = (x - 24 + 1, y - 7 - 32);
        private void SetEasternLeftUpperTrapezoid(int x, int y) => Coordinates[x, y] = (x - 24, y - 34);
        private void SetEasternRightUpperTrapezoid(int x, int y) => Coordinates[x, y] = (x - 24, y - 50);
        private void SetSouthWestLowerTriangle(int x, int y) => Coordinates[x, y] = (x - 33 + 1, y - 6 - 14);
        private void SetSouthEastLowerTriangle(int x, int y) => Coordinates[x, y] = (x - 33 + 1, y - 6 - 48);
        private void SetCenterLowerTrapezoids(int x, int y, int minimumY) => Coordinates[x, y] = (x - 36 - 4, y - minimumY - 7);
    }
}
