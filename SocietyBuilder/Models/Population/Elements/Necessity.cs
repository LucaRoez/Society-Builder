namespace SocietyBuilder.Models.Population.Elements
{
    public class Necessity
    {
        public int Priority { get; set; }
        public string Name { get; set; }

        public Necessity(int priority, string name)
        {
            Priority = priority;
            Name = name;
        }
    }
}
