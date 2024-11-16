namespace SocietyBuilder.Models.Population.Features
{
    public class Necessity
    {
        public float Priority { get; set; }
        public string Name { get; set; }
        public float Weighing { get; set; }
        public int Level { get; set; }
        public float Satiety { get; set; }

        public Necessity(float priority, string name, int level)
        {
            Priority = priority;
            Name = name;
            Level = level;
        }
    }
}
