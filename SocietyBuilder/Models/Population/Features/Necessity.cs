namespace SocietyBuilder.Models.Population.Features
{
    public class Necessity
    {
        public int Priority { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Level { get; set; }

        public Necessity()
        {
        }
        public Necessity(int priority, string name)
        {
            Priority = priority;
            Name = name;
        }
    }
}
