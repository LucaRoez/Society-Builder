using SocietyBuilder.Models.Spaces.Interfaces;

namespace SocietyBuilder.Models.Spaces.Occupancy
{
    public class Woodland : IOccupancy
    {
        public (double, double) Range => throw new NotImplementedException();

        public IHumidity Humidity { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ITemperature Temperature { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public IAltitude Height { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public ILatitude Latitude { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
