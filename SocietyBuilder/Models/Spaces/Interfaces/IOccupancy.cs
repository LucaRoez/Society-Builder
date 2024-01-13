namespace SocietyBuilder.Models.Spaces.Interfaces
{
    public interface IOccupancy
    {
        (double,double) Range { get; }
        IHumidity Humidity { get; set; }
        ITemperature Temperature { get; set; }
        IAltitude Height { get; set; }
        ILatitude Latitude { get; set; }
    }
}
