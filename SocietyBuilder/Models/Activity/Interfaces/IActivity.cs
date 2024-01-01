namespace SocietyBuilder.Models.Activity.Interfaces
{
    public interface IActivity
    {
        public Dictionary<string, int> Ask { get; set; }
        public Dictionary<IActivity, double> Bid { get; set; }
    }
}
