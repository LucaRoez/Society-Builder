using SocietyBuilder.Models.Production.Raw.Livestock;
using SocietyBuilder.Models.Spaces.Interfaces;
using SocietyBuilder.Models.Spaces.Occupancy;
using SocietyBuilder.Models.Spaces.Occupancy.Elements;
using SocietyBuilder.Models.Spaces.Occupancy.Features.Biome;

namespace SocietyBuilder.Services.PhysicSpace
{
    public static class EnvironmentUtilities
    {
                //  Environment Name  //  Land Types Involved   //  Percentage Range
        public static Dictionary<IBiome, IOccupancy[]> Environments = new()
        {
            {
                new Tundra(),
                new IOccupancy[]
                {
                    new AridLand()
                }
            },
            {
                new AridDesert(),
                new IOccupancy[]
                {
                    new AridLand()
                    {

                    }
                }
            },
            {
                new SemiaridDesert(),
                new IOccupancy[]
                {
                    new AridLand(),
                    new Woodland()
                }
            },
            {
                new Taiga(),
                new IOccupancy[]
                {
                    new AridLand(),
                    new FertileLand(),
                    new Woodland()
                }
            },
            {
                new GrassSavanna(),
                new IOccupancy[]
                {
                    new AridLand(),
                    new FertileLand()
                }
            },
            {
                new XericShrubland(),
                new IOccupancy[]
                {
                    new AridLand(),
                    new Woodland(),
                    new FertileLand()
                }
            },
            {
                new TreeSavanna(),
                new IOccupancy[]
                {
                    new Woodland(),
                    new AridLand(),
                    new FertileLand()
                }
            },
            {
                new DrySteppe(),
                new IOccupancy[]
                {
                    new AridLand(),
                    new FertileLand(),
                    new Woodland()
                }
            },
            {
                new TemperateSteppe(),
                new IOccupancy[]
                {
                    new FertileLand(),
                    new Woodland(),
                    new AridLand()
                }
            },
            {
                new TemperateForest(),
                new IOccupancy[]
                {
                    new Woodland(),
                    new FertileLand(),
                    new DenseForest(),
                    new AridLand()
                }
            },
            {
                new SubtropicalDryForest(),
                new IOccupancy[]
                {
                    new Woodland(),
                    new FertileLand(),
                    new AridLand()
                }
            },
            {
                new SubtropicalRainforest(),
                new IOccupancy[]
                {
                    new DenseForest(),
                    new Woodland(),
                    new FertileLand()
                }
            },
            {
                new TropicalDryForest(),
                new IOccupancy[]
                {
                    new Woodland(),
                    new DenseForest(),
                    new FertileLand(),
                    new AridLand()
                }
            },
            {
                new TropicalRainforest(),
                new IOccupancy[]
                {
                    new DenseForest(),
                    new Woodland(),
                    new FertileLand()
                }
            }
        };

        public static Resource[] Resources = new[]
        {
            new Resource()
            {
            },
            new Resource()
            {
            }
        };
    }
}
