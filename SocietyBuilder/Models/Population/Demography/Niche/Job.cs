using SocietyBuilder.Models.Population.Interfaces.IDemography;

namespace SocietyBuilder.Models.Population.Demography.Niche
{
    public abstract class Job : INiche
    {
        public abstract int Id { get; }
        public float Level { get; set; } = 1;
        public float CapacityOfUse {  get; set; }
    }
}
