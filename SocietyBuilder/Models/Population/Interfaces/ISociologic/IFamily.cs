namespace SocietyBuilder.Models.Population.Interfaces.ISociologic
{
    public interface IFamily
    {
        public string Strategy {  get; set; }
        public int Number { get; set; }
        public List<Citizen> Leaders { get; set; }
        public List<Citizen> Boarders { get; set; }
    }
}
