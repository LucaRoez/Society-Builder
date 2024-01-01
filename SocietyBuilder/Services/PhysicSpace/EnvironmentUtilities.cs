using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Occupancy;

namespace SocietyBuilder.Services.PhysicSpace
{
    public static class EnvironmentUtilities
    {
                //  Environment Name  //  Land Types Involved   //  Percentage Range
        public static Dictionary<Dictionary<string, string[]>, Dictionary<IOccupancy, (int, int)>> Environments = new()
        {
            {
                new Dictionary<string, string[]>
                {
                    { "Damp Steppe", new string[] { "Cool", "Mid-High-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new AridLand() as IOccupancy, (0, 0) },
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Dried Steppe", new string[] { "Cold", "Mid-Low-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new AridLand() as IOccupancy, (0, 0) },
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Chilly Dried Forest", new string[] { "Chilly", "Mid-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new AridLand() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Subtropical Damp Forest", new string[] { "Warm", "Mid-High-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) },
                    { new AridLand() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Tropical Jungle", new string[] { "Hot", "High-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) },
                    { new AridLand() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Savanna", new string[] { "Stifling", "Mid-Low-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new AridLand() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Arid Desert", new string[] { "Suffocating", "Low-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new AridLand() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) },
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new DenseForest() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) }
                }
            },
            {
                new Dictionary<string, string[]>
                {
                    { "Tundra", new string[] { "Frosty", "Mid-Humidity", "Shore:false-Lake:false" } }
                },
                new Dictionary<IOccupancy, (int, int)>
                {
                    { new AridLand() as IOccupancy, (0, 0) },
                    { new Saltwater() as IOccupancy, (0, 0) },
                    { new SweetWater() as IOccupancy, (0, 0) },
                    { new FertileLand() as IOccupancy, (0, 0) },
                    { new Woodland() as IOccupancy, (0, 0) },
                    { new DenseForest() as IOccupancy, (0, 0) }
                }
            },
        };
    }
}
