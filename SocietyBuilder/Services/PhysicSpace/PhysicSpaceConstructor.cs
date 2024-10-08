﻿using SocietyBuilder.Models.Spaces;

namespace SocietyBuilder.Services.PhysicSpace
{
    public class PhysicSpaceConstructor : IPhysicConstructor
    {
        public Region CreateNewArea()
        {
            Region area = new();
            List<Zone> zones = new();

            (area, zones) = FillArea(area, zones);
            zones = FillZones(zones);

            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 0: area.NorthWest = zones[i]; break;
                    case 1: area.NorthCenter = zones[i]; break;
                    case 2: area.NorthEast = zones[i]; break;
                    case 3: area.SouthWest = zones[i]; break;
                    case 4: area.SouthCenter = zones[i]; break;
                    default: area.SouthEast = zones[i]; break;
                }
            }

            return area;
        }

        private (Region, List<Zone>) FillArea(Region area, List<Zone> zones)
        {
            var zoneNW = area.NorthWest = new Zone(1);
            var zoneNC = area.NorthCenter = new Zone(2);
            var zoneNE = area.NorthEast = new Zone(3);
            var zoneSW = area.SouthWest = new Zone(4);
            var zoneSC = area.SouthCenter = new Zone(5);
            var zoneSE = area.SouthEast = new Zone(6);

            zones.Add(zoneNW); zones.Add(zoneNC); zones.Add(zoneNE);
            zones.Add(zoneSW); zones.Add(zoneSC); zones.Add(zoneSE);

            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    zones[i].North = new Area(1);
                    zones[i].South = null;
                    zones[i].West = new Area(3);
                    zones[i].East = new Area(4);
                }
                else if (i == 1)
                {
                    zones[i].North = null;
                    zones[i].South = new Area(2);
                    zones[i].West = new Area(3);
                    zones[i].East = new Area(4);
                }
                else if (i == 2)
                {
                    zones[i].North = new Area(1);
                    zones[i].South = null;
                    zones[i].West = new Area(3);
                    zones[i].East = new Area(4);
                }
                else if (i == 3)
                {
                    zones[i].North = null;
                    zones[i].South = new Area(2);
                    zones[i].West = new Area(3);
                    zones[i].East = new Area(4);
                }
                else if (i == 4)
                {
                    zones[i].North = new Area(1);
                    zones[i].South = null;
                    zones[i].West = new Area(3);
                    zones[i].East = new Area(4);
                }
                else
                {
                    zones[i].North = null;
                    zones[i].South = new Area(2);
                    zones[i].West = new Area(3);
                    zones[i].East = new Area(4);
                }
            }

            return (area, zones);
        }

        private List<Zone> FillZones(List<Zone> zones)
        {
            foreach (var zone in zones)
            {
                if (zone.North != null)
                {
                    var northParcels = zone.North.MicroParcels = new Parcel[16, 16];
                    var westParcels = zone.West.MicroParcels = new Parcel[16, 16];
                    var eastParcels = zone.East.MicroParcels = new Parcel[16, 16];
                    (zone.North.MicroParcels, zone.West.MicroParcels, zone.East.MicroParcels) = DrawZoneWithNorth(northParcels, westParcels, eastParcels);
                }
                else
                {
                    var southParcels = zone.South.MicroParcels = new Parcel[16, 16];
                    var westParcels = zone.West.MicroParcels = new Parcel[16, 16];
                    var eastParcels = zone.East.MicroParcels = new Parcel[16, 16];
                    (zone.West.MicroParcels, zone.East.MicroParcels, zone.South.MicroParcels) = DrawZoneWithSouth(southParcels, westParcels, eastParcels);
                }
            }

            return zones;
        }

        private (Parcel[,], Parcel[,], Parcel[,]) DrawZoneWithNorth(Parcel[,] northParcels, Parcel[,] lowerWestParcels, Parcel[,] lowerEastParcels)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    northParcels = DrawNorthMicroParcels(northParcels);
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

        private (Parcel[,], Parcel[,], Parcel[,]) DrawZoneWithSouth(Parcel[,] southParcels, Parcel[,] upperWestParcels, Parcel[,] upperEastParcels)
        {
            for (int i = 0; i < 3; i++)
            {
                if (i == 0)
                {
                    southParcels = DrawSouthMicroParcels(southParcels);
                }
                else if (i == 1)
                {
                    upperWestParcels = DrawUpperEastMicroParcels(upperWestParcels);
                }
                else
                {
                    upperEastParcels = DrawUpperWestMicroParcels(upperEastParcels);
                }
            }
            return (upperWestParcels, upperEastParcels, southParcels);
        }

        private Parcel[,] DrawNorthMicroParcels(Parcel[,] northParcels)
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
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 2 && y >= 6 && y <= 9)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 3 && y >= 6 && y <= 9)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 4 && y >= 5 && y <= 10)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 5 && y >= 5 && y <= 10)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 6 && y >= 4 && y <= 11)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 7 && y >= 4 && y <= 11)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 8 && y >= 3 && y <= 12)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 9 && y >= 3 && y <= 12)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 10 && y >= 2 && y <= 13)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 11 && y >= 1 && y <= 14)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 12 && y >= 0 && y <= 15)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 13 && y >= 1 && y <= 14)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 14 && y >= 4 && y <= 11)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 15 && y >= 7 && y <= 8)
                        {
                            northParcels[x, y] = new(oId); oId++;
                        }
                        else
                        {
                            northParcels[x, y] = null;
                        }
                    }
                    else
                    {
                        northParcels[x, y] = null;
                    }
                }
            }
            return northParcels;
        }

        private Parcel[,] DrawSouthMicroParcels(Parcel[,] southParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x > 0)
                    {
                        if (x == 1 && y >= 7 && y <= 8)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 2 && y >= 4 && y <= 11)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 3 && y >= 1 && y <= 14)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 4 && y >= 0 && y <= 15)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 5 && y >= 1 && y <= 14)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 6 && y >= 2 && y <= 13)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 7 && y >= 3 && y <= 12)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 8 && y >= 3 && y <= 12)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 9 && y >= 4 && y <= 11)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 10 && y >= 4 && y <= 11)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 11 && y >= 5 && y <= 10)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 12 && y >= 5 && y <= 10)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 13 && y >= 6 && y <= 9)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 14 && y >= 6 && y <= 9)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 15 && y >= 7 && y <= 8)
                        {
                            southParcels[x, y] = new(oId); oId++;
                        }
                        else
                        {
                            southParcels[x, y] = null;
                        }
                    }
                    else
                    {
                        southParcels[x, y] = null;
                    }
                }
            }
            return southParcels;
        }

        private Parcel[,] DrawUpperWestMicroParcels(Parcel[,] upperWestParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x < 12)
                    {
                        if (x == 0 && y >= 0 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 1 && y >= 1 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 2 && y >= 2 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 3 && y >= 2 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 4 && y >= 3 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 5 && y >= 3 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 6 && y >= 4 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 7 && y >= 4 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 8 && y >= 5 && y <= 0)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 9 && y >= 5 && y <= 1)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 10 && y >= 6 && y <= 4)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 11 && y >= 7 && y <= 7)
                        {
                            upperWestParcels[x, y] = new(oId); oId++;
                        }
                        else
                        {
                            upperWestParcels[x, y] = null;
                        }
                    }
                    else
                    {
                        upperWestParcels[x, y] = null;
                    }
                }
            }
            return upperWestParcels;
        }

        private Parcel[,] DrawUpperEastMicroParcels(Parcel[,] upperEastParcels)
        {
            int oId = 1;
            for (int x = 0; x < 16; x++)
            {
                for (int y = 0; y < 16; y++)
                {
                    if (x > 3)
                    {
                        if (x == 4 && y >= 0 && y <= 0)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 5 && y >= 0 && y <= 1)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 6 && y >= 0 && y <= 2)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 7 && y >= 0 && y <= 2)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 8 && y >= 0 && y <= 3)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 9 && y >= 0 && y <= 3)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 10 && y >= 0 && y <= 4)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 11 && y >= 0 && y <= 4)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 12 && y >= 0 && y <= 5)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 13 && y >= 1 && y <= 5)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 14 && y >= 4 && y <= 6)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 15 && y >= 7 && y <= 7)
                        {
                            upperEastParcels[x, y] = new(oId); oId++;
                        }
                        else
                        {
                            upperEastParcels[x, y] = null;
                        }
                    }
                    else
                    {
                        upperEastParcels[x, y] = null;
                    }
                }
            }
            return upperEastParcels;
        }

        private Parcel[,] DrawLowerWestParcels(Parcel[,] lowerWestParcels)
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
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 5 && y >= 6 && y <= 11)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 6 && y >= 5 && y <= 14)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 7 && y >= 5 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 8 && y >= 4 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 9 && y >= 4 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 10 && y >= 3 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 11 && y >= 3 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 12 && y >= 2 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 13 && y >= 2 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 14 && y >= 1 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 15 && y >= 0 && y <= 15)
                        {
                            lowerWestParcels[x, y] = new(oId); oId++;
                        }
                        else
                        {
                            lowerWestParcels[x, y] = null;
                        }
                    }
                    else
                    {
                        lowerWestParcels[x, y] = null;
                    }
                }
            }
            return lowerWestParcels;
        }

        private Parcel[,] DrawLowerEastParcels(Parcel[,] lowerEastParcels)
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
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 5 && y >= 4 && y <= 9)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 6 && y >= 1 && y <= 14)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 7 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 8 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 9 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 10 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 11 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 12 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 13 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 14 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else if (x == 15 && y >= 0 && y <= 15)
                        {
                            lowerEastParcels[x, y] = new(oId); oId++;
                        }
                        else
                        {
                            lowerEastParcels[x, y] = null;
                        }
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
