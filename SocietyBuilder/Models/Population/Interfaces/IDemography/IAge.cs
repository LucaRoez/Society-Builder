namespace SocietyBuilder.Models.Population.Interfaces.IDemography
{
    public interface IAge
    {
        public string Age { get; set; }
        public float HealthModifier { get; set; }
        public float CapacityModifier { get; set; }
    }
}
