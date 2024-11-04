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

        public Parcel[] Neighbor { get; set; } = new Parcel[8];
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

        public Parcel[] SetNeighbors()
        {
            FillNeighbors();

            // borders check, because of the nulls outlined outside area from this parcels matrix shape
            if (Area.OID == 1)      // North Triangle
            {
                if (Row == 1 && Col == 7)
                {
                    // ahora tengo que calcular los vecinos de cada parcela afuera de su area e incluso zona llegado al caso
                }
                else if (Row == 1 && Col == 8)
                {

                }
                else if (Row == 2 && Col == 6)
                {

                }
                else if (Row == 2 && Col == 9)
                {

                }
                else if (Row == 3 && Col == 5)
                {

                }
                else if (Row == 3 && Col == 10)
                {

                }
                else if (Row == 4 && Col == 4)
                {

                }
                else if (Row == 4 && Col == 11)
                {

                }
                else if (Row == 5 && Col == 4)
                {

                }
                else if (Row == 5 && Col == 11)
                {

                }
                else if (Row == 6 && Col == 3)
                {

                }
                else if (Row == 6 && Col == 12)
                {

                }
                else if (Row == 7 && Col == 3)
                {

                }
                else if (Row == 7 && Col == 12)
                {

                }
                else if (Row == 8 && Col == 2)
                {

                }
                else if (Row == 8 && Col == 13)
                {

                }
                else if (Row == 9 && Col == 2)
                {

                }
                else if (Row == 9 && Col == 13)
                {

                }
                else if (Row == 10 && Col == 1)
                {

                }
                else if (Row == 10 && Col == 14)
                {

                }
                else if (Row == 11 && Col == 0)
                {

                }
                else if (Row == 11 && Col == 15)
                {

                }
                else if (Row == 12 && Col == 0)
                {

                }
                else if (Row == 12 && Col == 15)
                {
                }
                else if (Row == 13 && Col == 1)
                {

                }
                else if (Row == 13 && Col == 14)
                {

                }
                else if (Row == 14 && Col == 3)
                {

                }
                else if (Row == 14 && Col == 12)
                {

                }
                else if (Row == 15 && Col == 6)
                {

                }
                else if (Row == 15 && Col == 7)
                {

                }
                else if (Row == 15 && Col == 8)
                {

                }
                else if (Row == 15 && Col == 9)
                {

                }
            }
            else if (Area.OID == 2) // South Triangle
            {
                if (Row == 0 && Col == 6)
                {
                }
                else if (Row == 0 && Col == 7)
                {

                }
                else if (Row == 0 && Col == 8)
                {

                }
                else if (Row == 0 && Col == 9)
                {

                }
                else if (Row == 1 && Col == 3)
                {

                }
                else if (Row == 1 && Col == 12)
                {

                }
                else if (Row == 2 && Col == 1)
                {

                }
                else if (Row == 2 && Col == 14)
                {

                }
                else if (Row == 3 && Col == 0)
                {

                }
                else if (Row == 3 && Col == 15)
                {
                }
                else if (Row == 4 && Col == 0)
                {

                }
                else if (Row == 4 && Col == 15)
                {

                }
                else if (Row == 5 && Col == 1)
                {

                }
                else if (Row == 5 && Col == 14)
                {

                }
                else if (Row == 6 && Col == 2)
                {

                }
                else if (Row == 6 && Col == 13)
                {

                }
                else if (Row == 7 && Col == 2)
                {

                }
                else if (Row == 7 && Col == 13)
                {

                }
                else if (Row == 8 && Col == 3)
                {

                }
                else if (Row == 8 && Col == 12)
                {

                }
                else if (Row == 9 && Col == 3)
                {

                }
                else if (Row == 9 && Col == 12)
                {

                }
                else if (Row == 10 && Col == 4)
                {

                }
                else if (Row == 10 && Col == 11)
                {

                }
                else if (Row == 11 && Col == 4)
                {

                }
                else if (Row == 11 && Col == 11)
                {

                }
                else if (Row == 12 && Col == 5)
                {

                }
                else if (Row == 12 && Col == 10)
                {

                }
                else if (Row == 13 && Col == 6)
                {

                }
                else if (Row == 13 && Col == 9)
                {

                }
                else if (Row == 14 && Col == 7)
                {

                }
                else if (Row == 14 && Col == 8)
                {

                }
            }
            else if (Area.OID == 3) // West Trapezoid
            {
                // lower positioned shape
                if (Area.Zone.OID == 1 ||  Area.Zone.OID == 3 || Area.Zone.OID == 5)
                {
                    if (Row == 4 && Col == 7)
                    {

                    }
                    else if (Row == 4 && Col == 8)
                    {

                    }
                    else if (Row == 5 && Col == 7)
                    {

                    }
                    else if (Row == 5 && Col == 10)
                    {

                    }
                    else if (Row == 6 && Col == 6)
                    {

                    }
                    else if (Row == 6 && Col == 13)
                    {

                    }
                    else if (Row == 7 && Col == 5)
                    {

                    }
                    else if (Row == 7 && Col == 15)
                    {

                    }
                    else if (Row == 8 && Col == 5)
                    {

                    }
                    else if (Row == 8 && Col == 15)
                    {

                    }
                    else if (Row == 9 && Col == 4)
                    {

                    }
                    else if (Row == 9 && Col == 15)
                    {

                    }
                    else if (Row == 10 && Col == 4)
                    {

                    }
                    else if (Row == 10 && Col == 15)
                    {

                    }
                    else if (Row == 11 && Col == 3)
                    {

                    }
                    else if (Row == 11 && Col == 15)
                    {

                    }
                    else if (Row == 12 && Col == 3)
                    {

                    }
                    else if (Row == 12 && Col == 15)
                    {

                    }
                    else if (Row == 13 && Col == 2)
                    {

                    }
                    else if (Row == 13 && Col == 15)
                    {

                    }
                    else if (Row == 14 && Col == 1)
                    {

                    }
                    else if (Row == 14 && Col == 15)
                    {

                    }
                    else if (Row == 15 && Col == 0)
                    {

                    }
                    else if (Row == 15 && Col == 1)
                    {

                    }
                    else if (Row == 15 && Col == 2)
                    {

                    }
                    else if (Row == 15 && Col == 3)
                    {

                    }
                    else if (Row == 15 && Col == 4)
                    {

                    }
                    else if (Row == 15 && Col == 5)
                    {

                    }
                    else if (Row == 15 && Col == 6)
                    {

                    }
                    else if (Row == 15 && Col == 7)
                    {

                    }
                    else if (Row == 15 && Col == 8)
                    {

                    }
                    else if (Row == 15 && Col == 9)
                    {

                    }
                    else if (Row == 15 && Col == 10)
                    {

                    }
                    else if (Row == 15 && Col == 11)
                    {

                    }
                    else if (Row == 15 && Col == 12)
                    {

                    }
                    else if (Row == 15 && Col == 13)
                    {

                    }
                    else if (Row == 15 && Col == 14)
                    {

                    }
                    else if (Row == 15 && Col == 15)
                    {

                    }
                }

                // upper positioned shape
                if (Area.Zone.OID == 2 || Area.Zone.OID == 4 || Area.Zone.OID == 6)
                {
                    if (Row == 11 && Col == 7)
                    {

                    }
                    else if (Row == 11 && Col == 8)
                    {

                    }
                    else if (Row == 10 && Col == 7)
                    {

                    }
                    else if (Row == 10 && Col == 10)
                    {

                    }
                    else if (Row == 9 && Col == 6)
                    {

                    }
                    else if (Row == 9 && Col == 13)
                    {

                    }
                    else if (Row == 8 && Col == 5)
                    {

                    }
                    else if (Row == 8 && Col == 15)
                    {

                    }
                    else if (Row == 7 && Col == 5)
                    {

                    }
                    else if (Row == 7 && Col == 15)
                    {

                    }
                    else if (Row == 6 && Col == 4)
                    {

                    }
                    else if (Row == 6 && Col == 15)
                    {

                    }
                    else if (Row == 5 && Col == 4)
                    {

                    }
                    else if (Row == 5 && Col == 15)
                    {

                    }
                    else if (Row == 4 && Col == 3)
                    {

                    }
                    else if (Row == 4 && Col == 15)
                    {

                    }
                    else if (Row == 3 && Col == 3)
                    {

                    }
                    else if (Row == 3 && Col == 15)
                    {

                    }
                    else if (Row == 2 && Col == 2)
                    {

                    }
                    else if (Row == 2 && Col == 15)
                    {

                    }
                    else if (Row == 1 && Col == 1)
                    {

                    }
                    else if (Row == 1 && Col == 15)
                    {

                    }
                    else if (Row == 0 && Col == 0)
                    {

                    }
                    else if (Row == 0 && Col == 1)
                    {

                    }
                    else if (Row == 0 && Col == 2)
                    {

                    }
                    else if (Row == 0 && Col == 3)
                    {

                    }
                    else if (Row == 0 && Col == 4)
                    {

                    }
                    else if (Row == 0 && Col == 5)
                    {

                    }
                    else if (Row == 0 && Col == 6)
                    {

                    }
                    else if (Row == 0 && Col == 7)
                    {

                    }
                    else if (Row == 0 && Col == 8)
                    {

                    }
                    else if (Row == 0 && Col == 9)
                    {

                    }
                    else if (Row == 0 && Col == 10)
                    {

                    }
                    else if (Row == 0 && Col == 11)
                    {

                    }
                    else if (Row == 0 && Col == 12)
                    {

                    }
                    else if (Row == 0 && Col == 13)
                    {

                    }
                    else if (Row == 0 && Col == 14)
                    {

                    }
                    else if (Row == 0 && Col == 15)
                    {

                    }
                }
            }
            else if (Area.OID == 4) // East Trapezoid
            {
                // lower positioned shape
                if (Area.Zone.OID == 1 || Area.Zone.OID == 3 || Area.Zone.OID == 5)
                {
                    if (Row == 4 && Col == 7)
                    {

                    }
                    else if (Row == 4 && Col == 8)
                    {

                    }
                    else if (Row == 5 && Col == 5)
                    {

                    }
                    else if (Row == 5 && Col == 8)
                    {

                    }
                    else if (Row == 6 && Col == 2)
                    {

                    }
                    else if (Row == 6 && Col == 9)
                    {

                    }
                    else if (Row == 7 && Col == 0)
                    {

                    }
                    else if (Row == 7 && Col == 10)
                    {

                    }
                    else if (Row == 8 && Col == 0)
                    {

                    }
                    else if (Row == 8 && Col == 10)
                    {

                    }
                    else if (Row == 9 && Col == 0)
                    {

                    }
                    else if (Row == 9 && Col == 11)
                    {

                    }
                    else if (Row == 10 && Col == 0)
                    {

                    }
                    else if (Row == 10 && Col == 11)
                    {

                    }
                    else if (Row == 11 && Col == 0)
                    {

                    }
                    else if (Row == 11 && Col == 12)
                    {

                    }
                    else if (Row == 12 && Col == 0)
                    {

                    }
                    else if (Row == 12 && Col == 12)
                    {

                    }
                    else if (Row == 13 && Col == 0)
                    {

                    }
                    else if (Row == 13 && Col == 13)
                    {

                    }
                    else if (Row == 14 && Col == 0)
                    {

                    }
                    else if (Row == 14 && Col == 14)
                    {

                    }
                    else if (Row == 15 && Col == 0)
                    {

                    }
                    else if (Row == 15 && Col == 1)
                    {

                    }
                    else if (Row == 15 && Col == 2)
                    {

                    }
                    else if (Row == 15 && Col == 3)
                    {

                    }
                    else if (Row == 15 && Col == 4)
                    {

                    }
                    else if (Row == 15 && Col == 5)
                    {

                    }
                    else if (Row == 15 && Col == 6)
                    {

                    }
                    else if (Row == 15 && Col == 7)
                    {

                    }
                    else if (Row == 15 && Col == 8)
                    {

                    }
                    else if (Row == 15 && Col == 9)
                    {

                    }
                    else if (Row == 15 && Col == 10)
                    {

                    }
                    else if (Row == 15 && Col == 11)
                    {

                    }
                    else if (Row == 15 && Col == 12)
                    {

                    }
                    else if (Row == 15 && Col == 13)
                    {

                    }
                    else if (Row == 15 && Col == 14)
                    {

                    }
                    else if (Row == 15 && Col == 15)
                    {

                    }
                }

                // upper positioned shape
                if (Area.Zone.OID == 2 || Area.Zone.OID == 4 || Area.Zone.OID == 6)
                {
                    if (Row == 11 && Col == 7)
                    {

                    }
                    else if (Row == 11 && Col == 8)
                    {

                    }
                    else if (Row == 10 && Col == 5)
                    {

                    }
                    else if (Row == 10 && Col == 8)
                    {

                    }
                    else if (Row == 9 && Col == 2)
                    {

                    }
                    else if (Row == 9 && Col == 9)
                    {

                    }
                    else if (Row == 8 && Col == 0)
                    {

                    }
                    else if (Row == 8 && Col == 10)
                    {

                    }
                    else if (Row == 7 && Col == 0)
                    {

                    }
                    else if (Row == 7 && Col == 10)
                    {

                    }
                    else if (Row == 6 && Col == 0)
                    {

                    }
                    else if (Row == 6 && Col == 11)
                    {

                    }
                    else if (Row == 5 && Col == 0)
                    {

                    }
                    else if (Row == 5 && Col == 11)
                    {

                    }
                    else if (Row == 4 && Col == 0)
                    {

                    }
                    else if (Row == 4 && Col == 12)
                    {

                    }
                    else if (Row == 3 && Col == 0)
                    {

                    }
                    else if (Row == 3 && Col == 12)
                    {

                    }
                    else if (Row == 2 && Col == 0)
                    {

                    }
                    else if (Row == 2 && Col == 13)
                    {

                    }
                    else if (Row == 1 && Col == 0)
                    {

                    }
                    else if (Row == 1 && Col == 14)
                    {

                    }
                    else if (Row == 0 && Col == 0)
                    {

                    }
                    else if (Row == 0 && Col == 1)
                    {

                    }
                    else if (Row == 0 && Col == 2)
                    {

                    }
                    else if (Row == 0 && Col == 3)
                    {

                    }
                    else if (Row == 0 && Col == 4)
                    {

                    }
                    else if (Row == 0 && Col == 5)
                    {

                    }
                    else if (Row == 0 && Col == 6)
                    {

                    }
                    else if (Row == 0 && Col == 7)
                    {

                    }
                    else if (Row == 0 && Col == 8)
                    {

                    }
                    else if (Row == 0 && Col == 9)
                    {

                    }
                    else if (Row == 0 && Col == 10)
                    {

                    }
                    else if (Row == 0 && Col == 11)
                    {

                    }
                    else if (Row == 0 && Col == 12)
                    {

                    }
                    else if (Row == 0 && Col == 13)
                    {

                    }
                    else if (Row == 0 && Col == 14)
                    {

                    }
                    else if (Row == 0 && Col == 15)
                    {

                    }
                }
            }

            return Neighbor;
        }
        private void FillNeighbors()
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
        }

        public int RelativeDistance(Parcel startingPlace)
        {
            int x0 = startingPlace.Row, y0 = startingPlace.Col;
            int x1 = Row, y1 = Col;
            
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
