namespace SocietyBuilder.Models.Population.Features
{
    public class Satiety
    {
        public float Grade { get; set; }
        public Necessity Necessity { get; set; } = new Necessity();
    }
}
