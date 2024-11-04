namespace SocietyBuilder.Models.Population.Society
{
    public class AggregateDemand
    {
        public int Level { get; set; }
        public string Name { get; set; }
        public bool IsFlex { get; set; }
        public double Satiety { get; set; }

        public AggregateDemand(int level, string name, bool isFlex)
        {
            Level = level;
            Name = name;
            IsFlex = isFlex;
            Satiety = 1;
        }
        public AggregateDemand(int level, string name, bool isFlex, double satiety)
        {
            Level = level;
            Name = name;
            IsFlex = isFlex;
            Satiety = satiety;
        }
    }
}
