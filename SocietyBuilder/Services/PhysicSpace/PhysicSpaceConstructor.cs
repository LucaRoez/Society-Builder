using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PhysicSpace
{
    public class PhysicSpaceConstructor : IPhysicConstructor
    {
        public Region CreateNewRegion(string latitude)
        {
            Region region = new(latitude);
            List<Zone> zones = new();

            (region, zones) = FillZones(region, zones);
            zones = FillAreas(zones);

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0: region.NorthWest = zones[i]; break;
                    case 1: region.NorthCenter = zones[i]; break;
                    case 2: region.NorthEast = zones[i]; break;
                    case 3: region.SouthWest = zones[i]; break;
                    case 4: region.SouthCenter = zones[i]; break;
                    default: region.SouthEast = zones[i]; break;
                }
            }
            region.SetCoordinates();

            return region;
        }

        private (Region, List<Zone>) FillZones(Region region, List<Zone> zones)
        {
            // first I split the original Region object from their children Zones
            var zoneNW = region.NorthWest = new Zone(1, region);
            var zoneNC = region.NorthCenter = new Zone(2, region);
            var zoneNE = region.NorthEast = new Zone(3, region);
            var zoneSW = region.SouthWest = new Zone(4, region);
            var zoneSC = region.SouthCenter = new Zone(5, region);
            var zoneSE = region.SouthEast = new Zone(6, region);

            // just to work later comfortably
            zones.Add(zoneNW); zones.Add(zoneNC); zones.Add(zoneNE);
            zones.Add(zoneSW); zones.Add(zoneSC); zones.Add(zoneSE);

            for (int i = 0; i < 6; i++)
            {
                if (i == 0)         // North West
                {
                    zones[i].North = new Area(1, zoneNW);
                    zones[i].South = null;
                    zones[i].West = new Area(3, zoneNW);
                    zones[i].East = new Area(4, zoneNW);
                }
                else if (i == 1)    // North Center
                {
                    zones[i].North = null;
                    zones[i].South = new Area(2, zoneNC);
                    zones[i].West = new Area(3, zoneNC);
                    zones[i].East = new Area(4, zoneNC);
                }
                else if (i == 2)    // North East
                {
                    zones[i].North = new Area(1, zoneNE);
                    zones[i].South = null;
                    zones[i].West = new Area(3, zoneNE);
                    zones[i].East = new Area(4, zoneNE);
                }
                else if (i == 3)    // South West
                {
                    zones[i].North = null;
                    zones[i].South = new Area(2, zoneSW);
                    zones[i].West = new Area(3, zoneSW);
                    zones[i].East = new Area(4, zoneSW);
                }
                else if (i == 4)    // South Center
                {
                    zones[i].North = new Area(1, zoneSC);
                    zones[i].South = null;
                    zones[i].West = new Area(3, zoneSC);
                    zones[i].East = new Area(4, zoneSC);
                }
                else if (i == 5)    // South East
                {
                    zones[i].North = null;
                    zones[i].South = new Area(2, zoneSE);
                    zones[i].West = new Area(3, zoneSE);
                    zones[i].East = new Area(4, zoneSE);
                }
            }

            return (region, zones);
        }

        private List<Zone> FillAreas(List<Zone> zones)
        {
            foreach (var zone in zones)
            {
                if (zone.North != null)
                {
                    (zone.North.Parcels, zone.West.Parcels, zone.East.Parcels) = DrawAreaWithNorth(zone.North.Parcels, zone.West.Parcels, zone.East.Parcels);
                }
                else if (zone.South != null)
                {
                    (zone.West.Parcels, zone.East.Parcels, zone.South.Parcels) = DrawAreaWithSouth(zone.South.Parcels, zone.West.Parcels, zone.East.Parcels);
                }
            }

            return zones;
        }

        private (Parcel?[,], Parcel?[,], Parcel?[,]) DrawAreaWithNorth(Parcel?[,] northParcels, Parcel?[,] lowerWestParcels, Parcel?[,] lowerEastParcels)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    northParcels = DrawNorthParcels(northParcels);
                }
                else if (i == 1)
                {
                    lowerWestParcels = DrawLowerWestParcels(lowerWestParcels);
                }
                else
                {
                    lowerEastParcels = DrawLowerEastParcels(lowerEastParcels);
                }
            }
            return (northParcels, lowerWestParcels, lowerEastParcels);
        }

        private (Parcel?[,], Parcel?[,], Parcel?[,]) DrawAreaWithSouth(Parcel?[,] southParcels, Parcel?[,] upperWestParcels, Parcel?[,] upperEastParcels)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    southParcels = DrawSouthParcels(southParcels);
                }
                else if (i == 1)
                {
                    upperWestParcels = DrawUpperEastParcels(upperWestParcels);
                }
                else
                {
                    upperEastParcels = DrawUpperWestParcels(upperEastParcels);
                }
            }
            return (upperWestParcels, upperEastParcels, southParcels);
        }

        private Parcel?[,] DrawNorthParcels(Parcel?[,] northParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x > 0)
                    {
                        if (x == 1 && y >= 7 && y <=8)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 2 && y >= 6 && y <= 9)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 3 && y >= 5 && y <= 10)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 4 && y >= 4 && y <= 11)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 5 && y >= 4 && y <= 11)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 6 && y >= 3 && y <= 12)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 7 && y >= 3 && y <= 12)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 8 && y >= 2 && y <= 13)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 9 && y >= 2 && y <= 13)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 10 && y >= 1 && y <= 14)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 11 && y >= 0 && y <= 15)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 12 && y >= 0 && y <= 15)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 13 && y >= 1 && y <= 14)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 14 && y >= 3 && y <= 12)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 15 && y >= 6 && y <= 9)
                        {
                            northParcels[x, y] = new(oId, x, y);
                        }
                        else
                        {
                            northParcels[x, y] = null;
                        }

                        if (northParcels[x, y] != null) oId++;
                    }
                    else
                    {
                        northParcels[x, y] = null;
                    }
                }
            }
            return northParcels;
        }

        private Parcel?[,] DrawSouthParcels(Parcel?[,] southParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x < 15)
                    {
                        if (x == 0 && y >= 6 && y <= 9)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 1 && y >= 3 && y <= 12)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 2 && y >= 1 && y <= 14)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 3 && y >= 0 && y <= 15)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 4 && y >= 0 && y <= 15)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 5 && y >= 1 && y <= 14)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 6 && y >= 2 && y <= 13)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 7 && y >= 2 && y <= 13)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 8 && y >= 3 && y <= 12)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 9 && y >= 3 && y <= 12)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 10 && y >= 4 && y <= 11)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 11 && y >= 4 && y <= 11)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 12 && y >= 5 && y <= 10)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 13 && y >= 6 && y <= 9)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 14 && y >= 7 && y <= 8)
                        {
                            southParcels[x, y] = new(oId, x, y);
                        }
                        else
                        {
                            southParcels[x, y] = null;
                        }

                        if (southParcels[x, y] != null) oId++;
                    }
                    else
                    {
                        southParcels[x, y] = null;
                    }
                }
            }
            return southParcels;
        }

        private Parcel?[,] DrawUpperWestParcels(Parcel?[,] upperWestParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x < 12)
                    {
                        if (x == 0 && y >= 0 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 1 && y >= 1 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 2 && y >= 2 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 3 && y >= 3 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 4 && y >= 3 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 5 && y >= 4 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 6 && y >= 4 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 7 && y >= 5 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 8 && y >= 5 && y <= 15)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 9 && y >= 6 && y <= 13)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 10 && y >= 7 && y <= 10)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 11 && y >= 7 && y <= 8)
                        {
                            upperWestParcels[x, y] = new(oId, x, y);
                        }
                        else
                        {
                            upperWestParcels[x, y] = null;
                        }

                        if (upperWestParcels[x, y] != null) oId++;
                    }
                    else
                    {
                        upperWestParcels[x, y] = null;
                    }
                }
            }
            return upperWestParcels;
        }

        private Parcel?[,] DrawUpperEastParcels(Parcel?[,] upperEastParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x < 12)
                    {
                        if (x == 0 && y >= 0 && y <= 15)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 1 && y >= 0 && y <= 14)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 2 && y >= 0 && y <= 13)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 3 && y >= 0 && y <= 12)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 4 && y >= 0 && y <= 12)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 5 && y >= 0 && y <= 11)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 6 && y >= 0 && y <= 11)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 7 && y >= 0 && y <= 10)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 8 && y >= 0 && y <= 10)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 9 && y >= 2 && y <= 9)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 10 && y >= 5 && y <= 8)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 11 && y >= 7 && y <= 8)
                        {
                            upperEastParcels[x, y] = new(oId, x, y);
                        }
                        else
                        {
                            upperEastParcels[x, y] = null;
                        }

                        if (upperEastParcels[x, y] != null) oId++;
                    }
                    else
                    {
                        upperEastParcels[x, y] = null;
                    }
                }
            }
            return upperEastParcels;
        }

        private Parcel?[,] DrawLowerWestParcels(Parcel?[,] lowerWestParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x > 3)
                    {
                        if (x == 4 && y >= 7 && y <= 8)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 5 && y >= 7 && y <= 10)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 6 && y >= 6 && y <= 13)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 7 && y >= 5 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 8 && y >= 5 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 9 && y >= 4 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 10 && y >= 4 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 11 && y >= 3 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 12 && y >= 3 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 13 && y >= 2 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 14 && y >= 1 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 15 && y >= 0 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId, x, y);
                        }
                        else
                        {
                            lowerWestParcels[x, y] = null;
                        }

                        if (lowerWestParcels[x, y] != null) oId++;
                    }
                    else
                    {
                        lowerWestParcels[x, y] = null;
                    }
                }
            }
            return lowerWestParcels;
        }

        private Parcel?[,] DrawLowerEastParcels(Parcel?[,] lowerEastParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x > 3)
                    {
                        if (x == 4 && y >= 7 && y <= 8)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 5 && y >= 5 && y <= 8)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 6 && y >= 2 && y <= 9)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 7 && y >= 0 && y <= 10)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 8 && y >= 0 && y <= 10)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 9 && y >= 0 && y <= 11)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 10 && y >= 0 && y <= 11)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 11 && y >= 0 && y <= 12)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 12 && y >= 0 && y <= 12)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 13 && y >= 0 && y <= 13)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 14 && y >= 0 && y <= 14)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else if (x == 15 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId, x, y);
                        }
                        else
                        {
                            lowerEastParcels[x, y] = null;
                        }

                        if (lowerEastParcels[x, y] != null) oId++;
                    }
                    else
                    {
                        lowerEastParcels[x, y] = null;
                    }
                }
            }
            return lowerEastParcels;
        }
    }
}
