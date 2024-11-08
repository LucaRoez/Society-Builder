using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Population;
using SocietyBuilder.Models.Production.Interfaces.IManufactured.IConstruction;
using SocietyBuilder.Models.Production;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Humidity;

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

        public int Col {  get; set; }
        public int Row { get; set; }
        public Citizen[] Population { get; set; }
        public int Inhabitants { get; set; }
        public List<Product> Resources { get; set; }

        public Parcel?[] Neighbor { get; set; } = new Parcel[8];
        public Parcel LastClosest {  get; set; }
        public int G_Cost { get; set; }
        public int H_Cost { get; set; }
        public int F_Cost { get; set; }
        public bool IsDiagonal { get; set; }
        public bool IsBorder { get; set; }

        public Parcel()
        {
        }
        public Parcel(int id, int row, int col)
        {
            OID = id;
            Row = row;
            Col = col;
        }

        public Parcel?[] SetNeighbors()
        {
            foreach (Parcel? parcel in Area.Parcels)
            {
                if (parcel != null)
                {
                    // left top neighbor
                    if (parcel.Row == Row - 1 && parcel.Col == Col - 1) Neighbor[0] = parcel;
                    // top neighbor
                    else if (parcel.Row == Row - 1 && parcel.Col == Col) Neighbor[1] = parcel;
                    // right top neighbor
                    else if (parcel.Row == Row - 1 && parcel.Col == Col + 1) Neighbor[2] = parcel;
                    // left neighbor
                    else if (parcel.Row == Row && parcel.Col == Col - 1) Neighbor[3] = parcel;
                    // right neighbor
                    else if (parcel.Row == Row && parcel.Col == Col + 1) Neighbor[4] = parcel;
                    // left bottom neighbor
                    else if (parcel.Row == Row + 1 && parcel.Col == Col - 1) Neighbor[5] = parcel;
                    // bottom neighbor
                    else if (parcel.Row == Row + 1 && parcel.Col == Col) Neighbor[6] = parcel;
                    // right bottom neighbor
                    else if (parcel.Row == Row + 1 && parcel.Col == Col + 1) Neighbor[7] = parcel;
                }
            }

            return Neighbor;
        }



        public int RelativeDistance(Parcel startingPlace)
        {
            int x0 = startingPlace.Row, y0 = startingPlace.Col;
            int x1 = Row, y1 = Col;

            (int, int) startingCoordinate = (x0, y0);
            (int, int) endingCoordinate = (x1, y1);
            (int, int)? startingPoint = null;
            (int, int)? endingPoint = null;

            (int, int)?[,] map = startingPlace.Area.Zone.Region.Coordinates;
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x,y] == startingCoordinate) startingPoint = (x, y);
                    else if (map[x,y] == endingCoordinate) endingPoint = (x, y);
                    if (startingPoint != null && endingPoint != null) break;
                }
                if (startingPoint != null && endingPoint != null) break;
            }

            (int, int) sp = startingPoint != null ? (startingPoint.Value.Item1, startingPoint.Value.Item2) : (0, 0);
            (int, int) ep = endingPoint != null ? (endingPoint.Value.Item1, endingPoint.Value.Item2) : (0, 0);
            int distance = AbsoluteDistance(sp, ep, map);
        }

        private int AbsoluteDistance((int, int) startingPoint, (int, int) endingPoint, (int, int)?[,] map)
        {
            int x0 = startingPoint.Item1, y0 = startingPoint.Item2;
            int x1 = endingPoint.Item1, y1 = endingPoint.Item2;

            int dx = Math.Abs(x1 - x0), sx = x0 < x1 ? 1 : -1;
            int dy = -Math.Abs(y1 - y0), sy = y0 < y1 ? 1 : -1;

            return (int)Math.Sqrt(Math.Pow(dx,2) + Math.Pow(dy,2));
        }

        public Parcel Ken()
        {
            return new Parcel()
            {
                OID = OID,
                Row = Row,
                Col = Col,
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
