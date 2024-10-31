namespace SocietyBuilder.Models.Production.General
{
    public class Requirement
    {
        public int Id { get; set; }
        public int QuantityNeeded { get; set; }

        public Requirement()
        {
        }
        public Requirement(int quantity)
        {
            QuantityNeeded = quantity;
        }
        public Requirement(int id, int quantity)
        {
            Id = id;
            QuantityNeeded = quantity;
        }
    }
}
