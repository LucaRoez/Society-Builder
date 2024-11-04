namespace SocietyBuilder.Models.Population.Features
{
    public class Satiety
    {
        public float Grade { get; set; }
        public Necessity Necessity { get; set; } = new Necessity();

        public Satiety()
        {
        }
        public Satiety(Necessity necessity)
        {
            Necessity = necessity;
        }
        public Satiety(Necessity necessity, float grade)
        {
            Necessity = necessity;
            Grade = grade;
        }
    }
}
