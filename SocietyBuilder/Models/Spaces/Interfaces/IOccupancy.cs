namespace SocietyBuilder.Models.Spaces.Interfaces
{
    public interface IOccupancy
    {
        string Humidity { get; set; }
        string Temperature { get; set; }
        double Height { get; set; }
    }
}
