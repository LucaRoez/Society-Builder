namespace SocietyBuilder.Models.Population.Features
{
    public class Necessity
    {
        public float Priority { get; set; }
        public string Name { get; set; } = string.Empty;
        public float Weighing { get; set; }
        public int Level { get; set; }
        public float Satiety { get; set; }

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
