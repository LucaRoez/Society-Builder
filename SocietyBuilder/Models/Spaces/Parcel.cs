using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.IConstruction;
using SocietyBuilder.Models.Production;

namespace SocietyBuilder.Models.Spaces
{
    public class Parcel : IPhysicalSpace
    {
        public Guid ID { get; set; } = Guid.NewGuid();
        public int OID { get; set; }
        public Guid AreaID { get; set; }
        public int AreaOID { get; set; }
        public Area Area { get; set; }

        public IBuildable[,] Lands = new IBuildable[3,3];

        public int RelativeCol {  get; set; }
        public int RelativeRow { get; set; }
        public (int, int) AbsoluteCoordinate {  get; set; }
        public Citizen[] Population { get; set; }
        public int Inhabitants { get; set; }
        public List<Product> Resources { get; set; }

        public Parcel[] Neighbors { get; set; } = new Parcel[8];
        public Parcel? LastClosest {  get; set; }
        public int G_Cost { get; set; }
        public int H_Cost { get; set; }
        public int F_Cost => H_Cost + F_Cost;
        public bool IsDiagonal { get; set; }
        public bool IsBorder { get; set; }

        public Parcel()
        {
        }
        public Parcel(int id, int row, int col)
        {
            OID = id;
            RelativeRow = row;
            RelativeCol = col;
            LocateCoordinate();
            GetNeighbors();
        }

        public (int, int) LocateCoordinate()
        {
            (int, int)?[,] region = Area.Zone.Region.Coordinates;
            for (int x = 0; x < 48; x++)
            {
                for (int y = 0; y < 66; y++)
                {
                    if (region[x, y] == (RelativeRow, RelativeCol)) AbsoluteCoordinate = (x, y);
                }
            }

            return AbsoluteCoordinate;
        }
        public Parcel[] GetNeighbors()
        {
            Region region = Area.Zone.Region;
            (int, int)[] neighborCoordinates = new (int, int)[8];
            for (int dx = -1; dx <= 1; dx++)
            {
                for (int dy = -1; dy <= 1; dy++)
                {
                    if (dx == 0 && dy == 0) continue;

                    neighborCoordinates.Append((AbsoluteCoordinate.Item1 + dx, AbsoluteCoordinate.Item2 + dy));
                }
            }

            Parcel?[] neighbors = new Parcel[8]; int i = 0;
            foreach ((int, int) neighborCoordinate in neighborCoordinates)
            {
                if (neighborCoordinate.Item1 < 24)
                    neighbors[i] = SearchInNorth(neighborCoordinate);
                else
                    neighbors[i] = SearchInSouth(neighborCoordinate);
                i++;
            }
            i = 0;
            foreach (Parcel? parcel in neighbors)   // absurd null checking
            {
                if (parcel == null)
                {
                    (int, int) neighborCoordinate = neighborCoordinates[i];
                    if (neighborCoordinate.Item1 < 24)
                        neighbors[i] = SearchInSouth(neighborCoordinate);
                    else
                        neighbors[i] = SearchInNorth(neighborCoordinate);
                }
                i++;
            }
            Neighbors = neighbors;

            return Neighbors;
        }
        private Parcel? SearchInNorth((int, int) neighborCoordinate)
        {
            Region region = Area.Zone.Region;
            // north center
            foreach (Parcel? parcel in region.NorthCenter.South.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.NorthCenter.West.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.NorthCenter.East.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            // north west
            foreach (Parcel? parcel in region.NorthWest.North.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.NorthWest.West.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.NorthWest.East.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            // north east
            foreach (Parcel? parcel in region.NorthEast.North.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.NorthEast.West.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.NorthEast.East.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            return null;
        }
        private Parcel? SearchInSouth((int, int) neighborCoordinate)
        {
            Region region = Area.Zone.Region;
            // south center
            foreach (Parcel? parcel in region.SouthCenter.South.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.SouthCenter.West.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.SouthCenter.East.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            // south west
            foreach (Parcel? parcel in region.SouthWest.North.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.SouthWest.West.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.SouthWest.East.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            // south east
            foreach (Parcel? parcel in region.SouthEast.North.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.SouthEast.West.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            foreach (Parcel? parcel in region.SouthEast.East.Parcels)
            {
                if (parcel != null)
                    if (parcel.Row == neighborCoordinate.Item1 && parcel.Col == neighborCoordinate.Item2)
                        return parcel;
            }
            return null;
        }

        public (int, List<Parcel>)? FindClosestPath(Parcel startingPlace)
        {
            List<Parcel> openParcels = new() { startingPlace };
            HashSet<Parcel> closedParcels = new();
            int x0 = startingPlace.AbsoluteCoordinate.Item1, y0 = startingPlace.AbsoluteCoordinate.Item2;
            int x1 = AbsoluteCoordinate.Item1, y1 = AbsoluteCoordinate.Item2;

            (int, int)?[,] map = startingPlace.Area.Zone.Region.Coordinates;
            (int, int) startingCoordinate = (x0, y0), endingCoordinate = (x1, y1);

            // set start
            startingPlace.G_Cost = 0;
            startingPlace.H_Cost = RelativeDistance(startingCoordinate, endingCoordinate);
            // loop
            while (openParcels.Count > 0)
            {
                // find the closest parcel
                Parcel currentParcel = openParcels[0];
                foreach (Parcel parcel in openParcels)
                {
                    // search for the closest
                    if (parcel.F_Cost < currentParcel.F_Cost || (parcel.F_Cost == currentParcel.F_Cost && parcel.H_Cost < parcel.H_Cost))
                        currentParcel = parcel;
                }

                // target reached
                if (currentParcel == this) return TrackPath(startingPlace);

                openParcels.Remove(currentParcel);
                closedParcels.Add(currentParcel);

                // search for their neighbors
                foreach (Parcel neighbor in currentParcel.Neighbors)
                {
                    if (closedParcels.Contains(neighbor)) continue; // repeat filter

                    int newG_Cost = currentParcel.G_Cost + RelativeDistance(currentParcel.AbsoluteCoordinate, neighbor.AbsoluteCoordinate);
                    // set neighbors
                    if ((newG_Cost < neighbor.G_Cost) || !openParcels.Contains(neighbor))
                    {
                        neighbor.G_Cost = newG_Cost;    
                        neighbor.H_Cost = RelativeDistance(currentParcel.AbsoluteCoordinate, AbsoluteCoordinate);
                        neighbor.LastClosest = currentParcel;
                        // add to open if isn't to start to making the path
                        if (!openParcels.Contains(neighbor)) openParcels.Add(neighbor);
                    }
                }
            }
            return null;
        }
        private int RelativeDistance((int, int) startingPoint, (int, int) endingPoint)
        {
            int x0 = startingPoint.Item1, y0 = startingPoint.Item2;
            int x1 = endingPoint.Item1, y1 = endingPoint.Item2;
            int dx = Math.Abs(x1 - x0);
            int dy = -Math.Abs(y1 - y0);

            return dx < dy ? (dx - dy)*10 + dx*14 : (dy - dx)*10 + dy*14;
        }
        private (int, List<Parcel>) TrackPath(Parcel startPlace)
        {
            List<Parcel> path = new();
            Parcel current = this;
            while (current != startPlace)
            {
                if (current.LastClosest != null)
                {
                    path.Add(current);
                    current = current.LastClosest;
                }
                else
                    throw new Exception("Tracking Path failed: one of the tracked parcels failed to load its parent Parcel in its LastClosest property.");
            }
            path.Reverse();
            return (startPlace.G_Cost, path);
        }

        public Parcel Ken()
        {
            return new Parcel()
            {
                OID = OID,
                RelativeRow = RelativeRow,
                RelativeCol = RelativeCol,
                AbsoluteCoordinate = AbsoluteCoordinate,
                ID = ID,
                AreaID = AreaID,
                AreaOID = AreaOID,
                Area = Area,
                Lands = Lands,
                Population = Population,
                Inhabitants = Inhabitants,
                Resources = Resources
            };
        }
    }
}
